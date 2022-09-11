
using Core.Persistence.Repositories;

namespace Core.Security.Entities
{
    public class UserContact : Entity
    {
        public UserContact()
        {
        }

        public UserContact(int id,int userId, string gitHubAddress):this()
        {
            Id = id;
            UserId = userId;
            GitHubAddress = gitHubAddress;
        }


        public int UserId { get; set; }
        public User User { get; set; }
        public string GitHubAddress { get; set; }
    }
}