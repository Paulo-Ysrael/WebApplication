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
    public class AssociationController : ControllerBase
    {
        private readonly IAssociationAppService _associationAppService;

        public AssociationController(IAssociationAppService associationAppService)
        {
            _associationAppService = associationAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RegisterAssociation")]
        public async Task<IActionResult> RegisterAssociation([FromBody] AssociationRequest request)
        {
            var result = await _associationAppService.RegisterAssociation(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("DeleteAssociation")]
        public async Task<IActionResult> DeleteAssociation([FromBody] AssociationRequest request)
        {
            var result = await _associationAppService.DeleteAssociation(request);

            if (result.StatusCode != StatusCodes.Status200OK)
                return new ObjectResult(result.Messages) { StatusCode = result.StatusCode };

            return Ok(result.Result);
        }
    }
}
