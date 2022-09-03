using Core.Persistence.Repositories;
using ProgramingLanguage.Domain.Entities;
namespace ProgramingLanguage.Application.Repositories.ProgramingLanguages
{
    public interface ILanguageRepository: IAsyncRepository<Language>, IRepository<Language>
    {
    }
}
