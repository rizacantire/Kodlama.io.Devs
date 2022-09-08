using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace ProgramingLanguage.Domain.Entities
{
    public class UserContact : User
    {
        public string GitHubAddress { get; set; }
    }
}