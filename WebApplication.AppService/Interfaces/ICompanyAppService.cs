using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.ViewModel.Request;

namespace WebApplication.Application.Interfaces
{
    public interface ICompanyAppService
    {
        Task<AppServiceResponse> GetList();

        Task<AppServiceResponse> GetCompany(int identifier);

        Task<AppServiceResponse> GetCompanyByName(string name);

        Task<AppServiceResponse> GetCompanyByCnpj(string cnpj);

        Task<AppServiceResponse> RegisterCompany(CompanyRequest request);

        Task<AppServiceResponse> Update(CompanyRequest request);
    }
}
