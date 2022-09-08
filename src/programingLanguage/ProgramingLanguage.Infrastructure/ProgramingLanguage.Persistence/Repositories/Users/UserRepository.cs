using Core.Persistence.Repositories;
using Core.Security.Entities;
using ProgramingLanguage.Application.Repositories.Users;
using ProgramingLanguage.Persistence.Context;

namespace ProgramingLanguage.Persistence.Repositories.Users
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
