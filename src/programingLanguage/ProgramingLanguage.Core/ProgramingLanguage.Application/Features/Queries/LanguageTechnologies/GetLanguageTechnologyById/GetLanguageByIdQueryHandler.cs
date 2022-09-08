﻿using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using ProgramingLanguageTechnology.Application.Rules.LanguageTechnologies;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Features.Queries.LanguageTechnologies.GetLanguageTechnologies
{
    public class GetLanguageTechnologyByIdQueryHandler : IRequestHandler<GetLanguageTechnologyByIdQuery, LanguageTechnologyViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;


        public GetLanguageTechnologyByIdQueryHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<LanguageTechnologyViewModel> Handle(GetLanguageTechnologyByIdQuery request, CancellationToken cancellationToken)
        {

            LanguageTechnology? languageTechnology = await _languageTechnologyRepository.GetAsync(predicate: p => p.Id == request.Id);
            _languageTechnologyBusinessRules.LanguageTechnologyShouldExistWhenRequested(languageTechnology);
            LanguageTechnologyViewModel returnItem = _mapper.Map<LanguageTechnologyViewModel>(languageTechnology);

            return returnItem;
        }
    }
}
