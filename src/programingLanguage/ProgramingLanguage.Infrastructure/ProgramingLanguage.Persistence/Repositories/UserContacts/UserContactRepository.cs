using Core.Persistence.Repositories;
using Core.Security.Entities;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.UserContacts;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguage.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Persistence.Repositories.UserContacts
{
    public class UserContactRepository : EfRepositoryBase<UserContact, BaseDbContext>, IUserContactRepository
    {
        public UserContactRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
