using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;
using WebApplication.Domain.InterfacesRepository;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Infra.Data.Repository
{
    public class AssociationRepository : IAssociationRepository
    {
        private AppDbContext _context;
        static AppDbContext context = new AppDbContext();

        public AssociationRepository()
        {
            _context = context;
        }

        public async Task<Association> GetAssociation(int membersId, int companyId)
        {
            return await _context.Association.Where(x => x.MembersId.Equals(membersId) && x.CompanyId.Equals(companyId)).FirstOrDefaultAsync();
        }

        public async Task RegisterAssociation(Association association)
        {
            _context.Association.Add(association);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssociation(Association association)
        {
            _context.Association.Remove(association);
            await _context.SaveChangesAsync();
        }
    }
}
