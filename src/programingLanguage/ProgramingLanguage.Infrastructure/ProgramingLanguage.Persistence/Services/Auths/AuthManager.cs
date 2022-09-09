using Application.Services.Auths;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using ProgramingLanguage.Application.Repositories.Users;

namespace Application.Services.Auths
{
    public class AuthManager : IAuthService
    {
        IUserOperationClaimRepository _userOperationClaimRepository;
        ITokenHelper _tokenHelper;
        private IUserRepository _userRepository;


        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                                                             include: u =>
                                                                 u.Include(u => u.OperationClaim)
            );
            List<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userRepository.GetAsync(p=>p.Email == userForLoginDto.Email);
            if (userToCheck == null)
                throw new BusinessException("Kullanýcý bulunamadý");

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                throw new BusinessException("Parola hatasý");
            return userToCheck;
        }
    

        public async Task<bool> UserExists(string email)
        {
            var userToCheck = await _userRepository.GetAsync(p => p.Email == email);
            if (userToCheck != null)
                throw new BusinessException("Kullanýcý zaten mevcut");

            return true;
        }
    
    }
}