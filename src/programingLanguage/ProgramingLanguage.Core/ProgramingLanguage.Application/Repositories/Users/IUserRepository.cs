using Core.Persistence.Repositories;
using Core.Security.Entities;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Repositories.Users
{
    public interface IUserRepository:IAsyncRepository<User>, IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
