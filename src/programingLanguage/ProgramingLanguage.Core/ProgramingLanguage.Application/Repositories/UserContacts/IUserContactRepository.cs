using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Repositories.UserContacts
{
    public interface IUserContactRepository : IAsyncRepository<UserContact>,IRepository<UserContact>
    {
    }
}
