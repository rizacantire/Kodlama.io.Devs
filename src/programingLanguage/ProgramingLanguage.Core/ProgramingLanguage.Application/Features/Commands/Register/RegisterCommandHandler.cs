using Application.Models.Register;
using Application.Services.Auths;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using ProgramingLanguage.Application.Repositories.Users;

namespace Application.Features.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredModel>
        {
            IUserRepository _userRepository;
            IAuthService _authService;

            public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService)
            {
                _userRepository = userRepository;
                _authService = authService;
            }

            public async Task<RegisteredModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passWordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passWordHash,out passwordSalt);
                User user = new User
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passWordHash,
                    PasswordSalt = passwordSalt
                };
                User createdUser = await _userRepository.AddAsync(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
                RegisteredModel registeredModel = new RegisteredModel
                {
                    AccessToken = createdAccessToken
                };
                return registeredModel;
            }
        }
}