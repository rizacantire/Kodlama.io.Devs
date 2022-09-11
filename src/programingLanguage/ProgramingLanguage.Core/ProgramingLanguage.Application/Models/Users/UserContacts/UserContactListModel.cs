using Core.Persistence.Paging;
using ProgramingLanguage.Application.Models.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Models.Users.UserContacts
{
    public class UserContactListModel : BasePageableModel
    {
        public IList<UserContactViewModel> Items { get; set; }

    }
}
