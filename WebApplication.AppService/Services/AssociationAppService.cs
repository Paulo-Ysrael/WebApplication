using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Application.ViewModel.Request;
using WebApplication.Domain.Entity;
using WebApplication.Domain.Interfaces;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Application.Services
{
    public class AssociationAppService: AppService, IAssociationAppService
    {
        private readonly IAssociationService _associationService;
        private readonly IMembersService _membersService;
        private readonly ICompanyService _companyService;
        private readonly AppDbContext _context;

        public AssociationAppService(IAssociationService associationService, IMembersService membersService, ICompanyService companyService, AppDbContext context)
        {
            _associationService = associationService;
            _membersService = membersService;
            _companyService = companyService;
            _context = context;
        }

        public async Task<AppServiceResponse> RegisterAssociation(AssociationRequest request)
        {
            var members = await _membersService.GetMembers(request.MembersId);

            if (members is null)
                return Fail(StatusCodes.Status404NotFound, "Associado não encontrado para o identificador informado!");

            var company = await _companyService.GetCompany(request.CompanyId);

            if (company is null)
                return Fail(StatusCodes.Status404NotFound, "Empresa não encontrada para o identificador informado!");

            var association = await _associationService.GetAssociation(members.Identifier, company.Identifier);

            if (!(association is null))
                return Fail(StatusCodes.Status400BadRequest, "Associação já feita anteriormente!");

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _associationService.RegisterAssociation(Association.Create(request.MembersId, request.CompanyId));

                return Ok("Associação feita com sucesso!");
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao salvar associação!");
            }
        }

        public async Task<AppServiceResponse> DeleteAssociation(AssociationRequest request)
        {
            var association = await _associationService.GetAssociation(request.MembersId, request.CompanyId);

            if (association is null)
                return Fail(StatusCodes.Status404NotFound, "Associação não encontrada!");

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _associationService.DeleteAssociation(association);

                return Ok("Associação deletada com sucesso!");
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao deletar associação!");
            }
        }
    }
}
