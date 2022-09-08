using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramingLanguage.API.Controllers.Common;
using ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage;
using ProgramingLanguage.Application.Features.Commands.Languages.DeleteLanguage;
using ProgramingLanguage.Application.Features.Commands.Languages.UpdateLanguage;
using ProgramingLanguage.Application.Features.Queries.Languages.GetLanguages;
using ProgramingLanguage.Application.Features.Queries.Languages.GetLanguagesByDynamic;
using ProgramingLanguage.Application.Models.Languages;

namespace ProgramingLanguage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetLanguagesQuery getLanguagesQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getLanguagesQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetLanguageByIdQuery query)
        {
            LanguageViewModel response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLanguageCommand command)
        {
            LanguageViewModel result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand query)
        {
            bool result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetLanguagesByDynamicQuery getLanguagesByDynamicQuery = new GetLanguagesByDynamicQuery { PageRequest = pageRequest, Dynamic = dynamic };
            LanguageListModel result = await Mediator.Send(getLanguagesByDynamicQuery);
            return Ok(result);

        }
    }
}
