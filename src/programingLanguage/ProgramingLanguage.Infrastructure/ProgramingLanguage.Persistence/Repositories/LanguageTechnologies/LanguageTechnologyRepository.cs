using Core.Persistence.Repositories;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguage.Persistence.Context;


namespace ProgramingLanguage.Persistence.Repositories.LanguageTechnologies
{
    public class LanguageTechnologyRepository : EfRepositoryBase<LanguageTechnology, BaseDbContext>, ILanguageTechnologyRepository
    {
        public LanguageTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
