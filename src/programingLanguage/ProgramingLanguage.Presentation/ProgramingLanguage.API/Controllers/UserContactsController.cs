using Core.Application.Requests;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramingLanguage.API.Controllers.Common;
using ProgramingLanguage.Application.Features.Commands.Users.UserContacts.AddUserContact;
using ProgramingLanguage.Application.Features.Commands.Users.UserContacts.DeleteUserContact;
using ProgramingLanguage.Application.Features.Commands.Users.UserContacts.UpdateUserContact;
using ProgramingLanguage.Application.Features.Queries.Users.UserContacts.GetUserContactByUserId;
using ProgramingLanguage.Application.Features.Queries.Users.UserContacts.GetUserContacts;
using ProgramingLanguage.Application.Models.Users.UserContacts;

namespace ProgramingUserContact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserContactsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetUserContactsQuery getUserContactsQuery = new() { PageRequest = pageRequest };
            UserContactListModel result = await Mediator.Send(getUserContactsQuery);
            return Ok(result);
        }

        [HttpGet("ByUserId")]
        public async Task<IActionResult> GetByUserId()
        {
            var query = new GetUserContactByUserIdQuery();
            var currentUserId = User.GetUserId();
            query.UserId = currentUserId;

            var response = await Mediator.Send(query);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserContactCommand command)
        {
            
            UserContactViewModel result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserContactCommand query)
        {
            int result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserContactCommand query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
