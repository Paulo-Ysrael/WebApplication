using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class MembersController : ControllerBase
    {
        private readonly IMermbersAppService _membersAppService;

        public MembersController(IMermbersAppService membersAppService)
        {
            _membersAppService = membersAppService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _membersAppService.GetList();

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByIdentifier/{identifier}")]
        public async Task<IActionResult> GetByIdentifier([FromQuery] int identifier)
        {
            var result = await _membersAppService.GetMembers(identifier);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var result = await _membersAppService.GetMembersByName(name);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByCpf/{cpf}")]
        public async Task<IActionResult> GetByCpf([FromQuery] string cpf)
        {
            var result = await _membersAppService.GetMembersByCpf(cpf);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterMember")]
        public async Task<IActionResult> RegisterMember([FromBody] MembersRequest request)
        {
            var result = await _membersAppService.RegisterMember(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] MembersRequest request)
        {
            var result = await _membersAppService.Update(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }
    }
}
