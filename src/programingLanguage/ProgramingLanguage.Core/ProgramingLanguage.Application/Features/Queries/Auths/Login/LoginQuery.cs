using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Auths.Login
{
    public class LoginQuery : UserForLoginDto, IRequest<bool>
    {
    }
}
