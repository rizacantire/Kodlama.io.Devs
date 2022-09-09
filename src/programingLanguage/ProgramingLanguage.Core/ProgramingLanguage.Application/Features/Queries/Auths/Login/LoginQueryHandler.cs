using Application.Services.Auths;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using ProgramingLanguage.Application.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Auths.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public LoginQueryHandler(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            UserForLoginDto loginDto = _mapper.Map<UserForLoginDto>(request);
            var userCheck = await _authService.LoginDto(loginDto);
            if (userCheck == null)
                throw new BusinessException("Kullanıcı bulunamadı"); 
            AccessToken getAccessToken =await _authService.CreateAccessToken(userCheck);
            return getAccessToken.Token.ToString();
        }
    }
}
