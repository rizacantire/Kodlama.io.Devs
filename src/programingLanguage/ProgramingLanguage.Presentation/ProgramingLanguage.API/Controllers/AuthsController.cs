using Application.Features.Commands.Register;
using Application.Models.Register;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramingLanguage.API.Controllers.Common;
using ProgramingLanguage.Application.Features.Queries.Auths.Login;

namespace ProgramingLanguage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
    
            var result = await Mediator.Send(command);
            return Created("", result.AccessToken);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
