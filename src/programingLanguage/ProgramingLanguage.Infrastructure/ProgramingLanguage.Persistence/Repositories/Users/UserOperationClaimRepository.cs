using Core.Persistence.Repositories;
using Core.Security.Entities;
using ProgramingLanguage.Application.Repositories.Users;
using ProgramingLanguage.Persistence.Context;

namespace ProgramingLanguage.Persistence.Repositories.Users
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
