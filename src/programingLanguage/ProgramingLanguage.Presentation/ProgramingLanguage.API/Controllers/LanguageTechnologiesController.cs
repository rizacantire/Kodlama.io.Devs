using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramingLanguage.API.Controllers.Common;
using ProgramingLanguage.Application.Features.Commands.LanguageTechnologies.AddLanguageTechnology;
using ProgramingLanguage.Application.Features.Queries.Languages.GetLanguagesByDynamic;
using ProgramingLanguage.Application.Features.Queries.Languages.GetLanguageTechnologiesByDynamic;
using ProgramingLanguageTechnology.Application.Features.Commands.LanguageTechnologyies.DeleteLanguageTechnology;
using ProgramingLanguageTechnology.Application.Features.Commands.LanguageTechnologyies.UpdateLanguageTechnology;
using ProgramingLanguageTechnology.Application.Features.Queries.LanguageTechnologies.GetLanguageTechnologies;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologyis;

namespace ProgramingLanguageTechnology.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologysController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetLanguageTechnologiesQuery getLanguageTechnologiesQuery = new() { PageRequest = pageRequest };
            LanguageTechnologyListModel result = await Mediator.Send(getLanguageTechnologiesQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetLanguageTechnologyByIdQuery query)
        {
            LanguageTechnologyViewModel response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLanguageTechnologyCommand command)
        {
            LanguageTechnologyViewModel result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageTechnologyCommand query)
        {
            bool result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetLanguageTechnologiesByDynamicQuery getLanguageTechnologiesByDynamicQuery = new GetLanguageTechnologiesByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            LanguageTechnologyListModel result = await Mediator.Send(getLanguageTechnologiesByDynamicQuery);
            return Ok(result);

        }

   
    }
}
