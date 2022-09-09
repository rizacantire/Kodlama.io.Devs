using Core.Security.Entities;
using ProgramingLanguage.Application.Repositories.Users;

namespace Application.Services.Auths
{
    public class UserManager : IUserService
    {
        IUserRepository _userDal;

        public UserManager(IUserRepository userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.AddAsync(user);
        }

        public async Task<User> GetByMail(string email)
        {
            User user = await _userDal.GetAsync(u => u.Email == email);
            return user;
        }


    }
}
