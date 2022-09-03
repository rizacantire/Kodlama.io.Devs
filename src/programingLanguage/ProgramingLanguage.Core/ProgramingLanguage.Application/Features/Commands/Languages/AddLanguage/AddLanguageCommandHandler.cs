using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Rules.Languages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage
{
    public class AddLanguageCommandHandler : IRequestHandler<AddLanguageCommand, LanguageViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public AddLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<LanguageViewModel> Handle(AddLanguageCommand request, CancellationToken cancellationToken)
        {
            await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            Language languageEntity = _mapper.Map<Language>(request);
            Language result = await _languageRepository.AddAsync(languageEntity);
            LanguageViewModel returnItem = _mapper.Map<LanguageViewModel>(result);

            return returnItem;

        }
    }
}
