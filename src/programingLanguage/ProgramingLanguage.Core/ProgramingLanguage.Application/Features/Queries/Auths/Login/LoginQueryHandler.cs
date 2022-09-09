using Application.Services.Auths;
using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Auths.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, bool>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authRepository;
        public async Task<bool> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userCheck = await _authRepository.Login(request);
            if (userCheck == null)
                return false;
            
            return true;
        }
    }
}
