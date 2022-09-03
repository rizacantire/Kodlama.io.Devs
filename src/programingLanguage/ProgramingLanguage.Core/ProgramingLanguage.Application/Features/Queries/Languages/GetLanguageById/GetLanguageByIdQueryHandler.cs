using AutoMapper;
using Core.Persistence.Paging;
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

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguages
{
    public class GetLanguageByIdQueryHandler : IRequestHandler<GetLanguageByIdQuery, LanguageViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;


        public GetLanguageByIdQueryHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<LanguageViewModel> Handle(GetLanguageByIdQuery request, CancellationToken cancellationToken)
        {

            Language? language = await _languageRepository.GetAsync(predicate: p => p.Id == request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(language);
            LanguageViewModel returnItem = _mapper.Map<LanguageViewModel>(language);

            return returnItem;
        }
    }
}
