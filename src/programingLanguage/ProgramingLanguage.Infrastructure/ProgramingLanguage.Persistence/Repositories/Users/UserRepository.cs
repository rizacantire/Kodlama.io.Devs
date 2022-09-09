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
        public List<OperationClaim> GetClaims(User user)
        {
            
                var result = from operationClaim in base.Context.OperationClaims
                             join userOperationClaim in base.Context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
        }    
    }
}
