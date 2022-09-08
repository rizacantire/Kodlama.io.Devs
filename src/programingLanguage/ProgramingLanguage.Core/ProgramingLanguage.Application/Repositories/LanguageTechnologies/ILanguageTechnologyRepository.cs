using Core.Persistence.Repositories;
using ProgramingLanguage.Domain.Entities;
namespace ProgramingLanguage.Application.Repositories.ProgramingLanguages
{
    public interface ILanguageTechnologyRepository: IAsyncRepository<LanguageTechnology>, IRepository<LanguageTechnology>
    {
    }
}
