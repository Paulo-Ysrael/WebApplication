using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Application.ViewModel.Request;
using WebApplication.Application.ViewModel.Response;
using WebApplication.Domain.Entity;
using WebApplication.Domain.Interfaces;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Application.Services
{
    public class MermbersAppService : AppService, IMermbersAppService
    {
        private readonly IMembersService _membersService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public MermbersAppService(IMembersService membersService, IMapper mapper, AppDbContext context)
        {
            _membersService = membersService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AppServiceResponse> GetList()
        {
            return Ok(_mapper.Map<List<MembersResponse>>(await _membersService.GetList()));
        }

        public async Task<AppServiceResponse> GetMembers(int identifier)
        {
            var members = await _membersService.GetMembers(identifier);

            if (members is null)
                return Fail(StatusCodes.Status404NotFound, "Associado não encontrado para o identificador informado!");

            var result = _mapper.Map<MembersResponse>(members);

            return Ok(result);
        }

        public async Task<AppServiceResponse> GetMembersByName(string name)
        {
            var members = await _membersService.GetMembersByName(name);

            if (members is null)
                return Fail(StatusCodes.Status404NotFound, "Não há associados com esse nome!");

            var result = _mapper.Map<List<MembersResponse>>(members);

            return Ok(result);
        }

        public async Task<AppServiceResponse> GetMembersByCpf(string cpf)
        {
            var members = await _membersService.GetMembersByCpf(cpf);

            if (members is null)
                return Fail(StatusCodes.Status404NotFound, "Associado não encontrado para o cpf informado!");

            var result = _mapper.Map<MembersResponse>(members);

            return Ok(result);
        }

        public async Task<AppServiceResponse> RegisterMember(MembersRequest request)
        {
            var members = await _membersService.GetMembersByCpf(request.CPF);

            if (!(members is null))
                return Fail(StatusCodes.Status400BadRequest, "Há um associado com o cpf informado!");

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _membersService.RegisterMember(Members.Create(request.Name, request.CPF, request.Birth));

                return Ok("Associado criado com sucesso!");
            }
            catch 
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao salvar associado!");
            }
        }

        public async Task<AppServiceResponse> Update(MembersRequest request)
        {
            Members members = new();

            members = await _membersService.GetMembersByCpf(request.CPF);

            if (!(members is null))
                return Fail(StatusCodes.Status400BadRequest, "Há um associado com o cpf informado!");

            members = await _membersService.GetMembers(request.Identifier.Value);

            if (members is null)
                return Fail(StatusCodes.Status404NotFound, "Associado não encontrado para o identificador informado!");

            members.Name = request.Name;
            members.CPF = request.CPF;
            members.Birth = DateTime.Parse(request.Birth);

            var transaction = _context.Database.BeginTransaction();

            try
            {
                await _membersService.Update(members);

                return Ok("Associado alterado com sucesso!");
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();

                return Fail(StatusCodes.Status500InternalServerError, "Erro ao alterar associado!");
            }
        }
    }
}
