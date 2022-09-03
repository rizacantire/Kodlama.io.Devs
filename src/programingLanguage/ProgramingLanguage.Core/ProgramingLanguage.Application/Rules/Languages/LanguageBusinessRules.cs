using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Rules.Languages
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageShouldExistWhenRequested(Language item)
        {
            if (item == null) throw new BusinessException("Requested Language does not exist");
        }
    }
}
