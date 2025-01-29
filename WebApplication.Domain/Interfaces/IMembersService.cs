using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;

namespace WebApplication.Domain.Interfaces
{
    public interface IMembersService
    {
        Task<List<Members>> GetList();

        Task<Members> GetMembers(int identifier);

        Task<List<Members>> GetMembersByName(string name);

        Task<Members> GetMembersByCpf(string cpf);

        Task RegisterMember(Members members);

        Task Update(Members members);
    }
}
