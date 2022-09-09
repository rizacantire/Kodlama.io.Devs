using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Rules.LanguageTechnologies
{
    public class LanguageTechnologyBusinessRules
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

        public LanguageTechnologyBusinessRules(ILanguageTechnologyRepository languageTechnologyRepository)
        {
            _languageTechnologyRepository = languageTechnologyRepository;
        }

        public async Task LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<LanguageTechnology> result = await _languageTechnologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("LanguageTechnology name exists.");
        }

        public void LanguageTechnologyShouldExistWhenRequested(LanguageTechnology item)
        {
            if (item == null) throw new BusinessException("Requested LanguageTechnology does not exist");
        }
    }
}
