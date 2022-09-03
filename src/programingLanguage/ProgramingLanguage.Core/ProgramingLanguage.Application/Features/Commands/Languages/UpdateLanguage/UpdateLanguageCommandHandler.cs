using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Rules.Languages;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Languages.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, LanguageViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public UpdateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<LanguageViewModel> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetByIdAsync(request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(language);

            await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
           
            language.Name = request.Name;
            await _languageRepository.UpdateAsync(language);
            var returnItem = _mapper.Map<LanguageViewModel>(language);

            return returnItem;
        }
    }
}
