﻿using Core.Persistence.Repositories;

namespace ProgramingLanguage.Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<LanguageTechnology> LanguageTechnologies { get; set; }

        public Language()
        {

        }

        public Language(int id,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
