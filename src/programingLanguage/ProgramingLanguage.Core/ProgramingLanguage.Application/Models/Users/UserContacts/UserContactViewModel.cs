using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Models.Users.UserContacts
{
    public class UserContactViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string GitHubAddress { get; set; }
    }
}
