using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;
using WebApplication.Domain.InterfacesRepository;
using WebApplication.Infra.Data.Context;

namespace WebApplication.Infra.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private AppDbContext _context;
        static AppDbContext context = new AppDbContext();

        public CompanyRepository()
        {
            _context = context;
        }

        public async Task<List<Company>> GetList()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<Company> GetCompany(int identifier)
        {
            return await _context.Company.Where(x => x.Identifier.Equals(identifier)).FirstOrDefaultAsync();
        }

        public async Task<List<Company>> GetCompanyByName(string name)
        {
            return await _context.Company.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<Company> GetCompanyByCnpj(string cnpj)
        {
            return await _context.Company.Where(x => x.CNPJ.Equals(cnpj)).FirstOrDefaultAsync();
        }

        public async Task RegisterCompany(Company company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Company company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
        }
    }
}
