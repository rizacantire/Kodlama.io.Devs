using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace ProgramingLanguage.Application.Repositories.Users
{
    public interface IUserRepository:IAsyncRepository<User>
    {
    }
}
