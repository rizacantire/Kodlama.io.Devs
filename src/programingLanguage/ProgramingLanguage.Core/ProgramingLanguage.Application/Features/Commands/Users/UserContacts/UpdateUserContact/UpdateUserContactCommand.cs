using MediatR;
using ProgramingLanguage.Application.Features.Commands.BaseCommands;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Users.UserContacts.UpdateUserContact
{
    public class UpdateUserContactCommand : UpdateUserContactViewModel,IRequest<UserContactViewModel>
    {
        public int Id { get; set; }
    }
}
