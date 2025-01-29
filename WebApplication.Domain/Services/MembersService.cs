using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;
using WebApplication.Domain.Interfaces;
using WebApplication.Domain.InterfacesRepository;

namespace WebApplication.Domain.Service
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;
        public MembersService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public async Task<List<Members>> GetList()
        {
            var result = await _membersRepository.GetList();

            if (result.Count.Equals((int)decimal.Zero))
                return null;

            return result;
        }

        public async Task<Members> GetMembers(int identifier)
        {
            var result = await _membersRepository.GetMembers(identifier);

            if (result is null)
                return null;

            return result;
        }

        public async Task<List<Members>> GetMembersByName(string name)
        {
            var result = await _membersRepository.GetMembersByName(name);

            if (result.Count.Equals((int)decimal.Zero))
                return null;

            return result;
        }

        public async Task<Members> GetMembersByCpf(string cpf)
        {
            var result = await _membersRepository.GetMembersByCpf(cpf);

            if (result is null)
                return null;

            return result;
        }

        public async Task RegisterMember(Members members)
        {
            await _membersRepository.RegisterMember(members);
        }

        public async Task Update(Members members)
        {
            await _membersRepository.Update(members);
        }
    }
}
