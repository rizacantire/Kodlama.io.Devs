using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguageTechnology.Application.Rules.LanguageTechnologies
{
    public class LanguageTechnologyBusinessRules
    {
        private readonly ILanguageTechnologyRepository _languageRepository;

        public LanguageTechnologyBusinessRules(ILanguageTechnologyRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<LanguageTechnology> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("LanguageTechnology name exists.");
        }

        public void LanguageTechnologyShouldExistWhenRequested(LanguageTechnology item)
        {
            if (item == null) throw new BusinessException("Requested LanguageTechnology does not exist");
        }
    }
}
