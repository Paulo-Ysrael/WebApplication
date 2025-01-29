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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetList()
        {
            var result = await _companyRepository.GetList();

            if (result is null)
                return null;

            return result;
        }

        public async Task<Company> GetCompany(int identifier)
        {
            var result = await _companyRepository.GetCompany(identifier);

            if (result is null)
                return null;

            return result;
        }

        public async Task<List<Company>> GetCompanyByName(string name)
        {
            var result = await _companyRepository.GetCompanyByName(name);

            if (result.Count.Equals((int)decimal.Zero))
                return null;

            return result;
        }

        public async Task<Company> GetCompanyByCnpj(string cnpj)
        {
            var result = await _companyRepository.GetCompanyByCnpj(cnpj);

            if (result is null)
                return null;

            return result;
        }

        public async Task RegisterCompany(Company company)
        {
            await _companyRepository.RegisterCompany(company);
        }

        public async Task Update(Company company)
        {
            await _companyRepository.Update(company);
        }
    }
}
