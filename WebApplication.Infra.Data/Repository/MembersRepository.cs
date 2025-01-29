using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;
using WebApplication.Domain.InterfacesRepository;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Infra.Data.Repository
{
    public class MembersRepository : IMembersRepository
    {
        private AppDbContext _context;
        static AppDbContext context = new AppDbContext();

        public MembersRepository()
        {
            _context = context;
        }

        public async Task<List<Members>> GetList()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Members> GetMembers(int identifier)
        {
            return await _context.Members.Where(x => x.Identifier.Equals(identifier)).FirstOrDefaultAsync();
        }

        public async Task<List<Members>> GetMembersByName(string name)
        {
            return await _context.Members.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Members> GetMembersByCpf(string cpf)
        {
            return await _context.Members.Where(x => x.CPF.Equals(cpf)).FirstOrDefaultAsync();
        }

        public async Task RegisterMember(Members members)
        {
            _context.Members.Add(members);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Members members)
        {
            _context.Members.Update(members);
            await _context.SaveChangesAsync();
        }
    }
}
