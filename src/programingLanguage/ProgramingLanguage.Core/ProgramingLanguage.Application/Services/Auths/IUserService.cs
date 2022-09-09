using Core.Security.Entities;

namespace Application.Services.Auths
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        Task<User> GetByMail(string email);
    }
}
