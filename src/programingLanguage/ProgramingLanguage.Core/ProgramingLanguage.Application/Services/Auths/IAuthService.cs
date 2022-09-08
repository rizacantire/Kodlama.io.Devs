using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.Auths
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
    }
}