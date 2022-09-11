using Core.Persistence.Repositories;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguage.Persistence.Context;

namespace ProgramingLanguage.Persistence.Repositories.Languages
{
    public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
