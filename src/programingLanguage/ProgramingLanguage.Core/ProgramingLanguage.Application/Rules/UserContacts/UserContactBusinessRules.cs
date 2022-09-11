using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.UserContacts;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Rules.UserContacts
{
    public class UserContactBusinessRules
    {
        private readonly IUserContactRepository _usercontactRepository;

        public UserContactBusinessRules(IUserContactRepository usercontactRepository)
        {
            _usercontactRepository = usercontactRepository;
        }

        public async Task UserContactCanNotBeDuplicatedWhenInserted(string gitHubAddress)
        {
            UserContact result = await _usercontactRepository.GetAsync(b => b.GitHubAddress == gitHubAddress);
            if (result != null) throw new BusinessException("UserContact name exists.");
        }
        

        public void UserContactShouldExistWhenRequested(UserContact item)
        {
            if (item == null) throw new BusinessException("Requested UserContact does not exist");
        }
    }
}
