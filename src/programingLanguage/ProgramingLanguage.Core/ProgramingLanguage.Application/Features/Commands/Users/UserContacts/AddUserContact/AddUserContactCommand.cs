using MediatR;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Users.UserContacts.AddUserContact
{
    public class AddUserContactCommand :AddUserContactModel, IRequest<UserContactViewModel>
    {
    }
}
