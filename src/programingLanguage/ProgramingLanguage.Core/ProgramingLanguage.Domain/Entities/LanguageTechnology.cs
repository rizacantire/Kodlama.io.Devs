using Core.Persistence.Repositories;

namespace ProgramingLanguage.Domain.Entities
{
    public class LanguageTechnology : Entity
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public LanguageTechnology()
        {

        }

        public LanguageTechnology(int id,string name,int languageId):this()
        {
            Id = id;
            Name = name;
            LanguageId = languageId;
        }
    }
}
