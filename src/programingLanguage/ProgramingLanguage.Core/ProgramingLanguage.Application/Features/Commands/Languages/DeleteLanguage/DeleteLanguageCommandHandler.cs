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

namespace ProgramingLanguage.Application.Features.Commands.Languages.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public DeleteLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<bool> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(predicate: p => p.Id == request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(language);
            await _languageRepository.DeleteAsync(language);
            return true;
        }
    }
}
