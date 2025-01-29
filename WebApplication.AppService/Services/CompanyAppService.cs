using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Application.ViewModel.Request;
using WebApplication.Application.ViewModel.Response;
using WebApplication.Domain.Entity;
using WebApplication.Domain.Interfaces;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Application.Services
{
    public class CompanyAppService : AppService, ICompanyAppService
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CompanyAppService(ICompanyService companyService, IMapper mapper, AppDbContext context)
        {
            _companyService = companyService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AppServiceResponse> GetList()
        {
            return Ok(_mapper.Map<List<CompanyResponse>>(await _companyService.GetList()));
        }

        public async Task<AppServiceResponse> GetCompany(int identifier)
        {
            var company = await _companyService.GetCompany(identifier);

            if (company is null)
                return Fail(StatusCodes.Status404NotFound, "Empresa não encontrada para o identificador informado!");

            var result = _mapper.Map<CompanyResponse>(company);

            return Ok(result);
        }

        public async Task<AppServiceResponse> GetCompanyByName(string name)
        {
            var company = await _companyService.GetCompanyByName(name);

            if (company is null)
                return Fail(StatusCodes.Status404NotFound, "Não há empresas com esse nome!");

            var result = _mapper.Map<List<CompanyResponse>>(company);

            return Ok(result);
        }

        public async Task<AppServiceResponse> GetCompanyByCnpj(string cnpj)
        {
            var company = await _companyService.GetCompanyByCnpj(cnpj);

            if (company is null)
                return Fail(StatusCodes.Status404NotFound, "Empresa não encontrada para o cpf informado!");

            var result = _mapper.Map<CompanyResponse>(company);

            return Ok(result);
        }

        public async Task<AppServiceResponse> RegisterCompany(CompanyRequest request)
        {
            var company = await _companyService.GetCompanyByCnpj(request.CNPJ);

            if (!(company is null))
                return Fail(StatusCodes.Status400BadRequest, "Há um associado com o cnpj informado!");

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _companyService.RegisterCompany(Company.Create(request.Name, request.CNPJ));

                return Ok("Empresa criada com sucesso!");
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao salvar empresa!");
            }
        }

        public async Task<AppServiceResponse> Update(CompanyRequest request)
        {
            Company company = new();

            company = await _companyService.GetCompanyByCnpj(request.CNPJ);

            if (!(company is null))
                return Fail(StatusCodes.Status400BadRequest, "Há um associado com o cnpj informado!");

            company = await _companyService.GetCompany(request.Identifier.Value);

            if (company is null)
                return Fail(StatusCodes.Status404NotFound, "Empresa não encontrada para o identificador informado!");

            company.Name = request.Name;
            company.CNPJ = request.CNPJ;

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _companyService.Update(company);

                return Ok("Empresa alterada com sucesso!");
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao alterar empresa!");
            }
        }
    }
}
