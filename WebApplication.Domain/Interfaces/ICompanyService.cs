using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;

namespace WebApplication.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetList();

        Task<Company> GetCompany(int identifier);

        Task<List<Company>> GetCompanyByName(string name);

        Task<Company> GetCompanyByCnpj(string cnpj);

        Task RegisterCompany(Company company);

        Task Update(Company company);
    }
}
