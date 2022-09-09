using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Auths.Login
{
    public class LoginQuery :  IRequest<string>
    {
         public string Email { get; set; }
        public string Password { get; set; }
        public string? AuthenticatorCode { get; set; }
    }
}
