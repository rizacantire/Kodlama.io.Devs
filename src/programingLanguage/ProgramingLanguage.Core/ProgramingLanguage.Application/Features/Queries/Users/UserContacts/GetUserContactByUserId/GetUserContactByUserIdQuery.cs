using MediatR;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Users.UserContacts.GetUserContactByUserId
{
    public class GetUserContactByUserIdQuery : IRequest<UserContactViewModel>
    {
        public int UserId { get; set; }
    }
}
