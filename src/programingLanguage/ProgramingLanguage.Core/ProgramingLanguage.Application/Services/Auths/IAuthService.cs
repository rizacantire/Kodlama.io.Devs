using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.Auths
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
        Task<User> Login(UserForLoginDto userForLoginDto);
        Task<bool> UserExists(string email);
        Task<User> LoginDto(UserForLoginDto loginDto);
    }
}