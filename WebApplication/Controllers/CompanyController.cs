using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Application.ViewModel.Request;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _companyAppService.GetList();

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByIdentifier/{identifier}")]
        public async Task<IActionResult> GetByIdentifier([FromQuery] int identifier)
        {
            var result = await _companyAppService.GetCompany(identifier);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var result = await _companyAppService.GetCompanyByName(name);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByCpf/{cpf}")]
        public async Task<IActionResult> GetByCpf([FromQuery] string cnpj)
        {
            var result = await _companyAppService.GetCompanyByCnpj(cnpj);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterCompany")]
        public async Task<IActionResult> RegisterCompany([FromBody] CompanyRequest request)
        {
            var result = await _companyAppService.RegisterCompany(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] CompanyRequest request)
        {
            var result = await _companyAppService.Update(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }
    }
}
