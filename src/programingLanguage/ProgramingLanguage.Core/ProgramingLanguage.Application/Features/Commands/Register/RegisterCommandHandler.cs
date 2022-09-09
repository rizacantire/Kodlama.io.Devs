using Application.Models.Register;
using Application.Services.Auths;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using ProgramingLanguage.Application.Repositories.Users;

namespace Application.Features.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;

        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, IMapper mapper = null)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<RegisteredModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passWordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password,out passWordHash,out passwordSalt);
                User user = _mapper.Map<User>(request);
                user.PasswordHash = passWordHash;
                user.PasswordSalt = passwordSalt;

                User createdUser = await _authService.Add(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RegisteredModel registeredModel = new RegisteredModel
                {
                    AccessToken = createdAccessToken
                };
                return registeredModel;
            }
        }
}