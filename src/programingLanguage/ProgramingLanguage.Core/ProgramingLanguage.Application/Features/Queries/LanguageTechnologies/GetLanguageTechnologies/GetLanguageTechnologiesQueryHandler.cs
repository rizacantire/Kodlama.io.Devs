using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologyis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Features.Queries.LanguageTechnologies.GetLanguageTechnologies
{
    public class GetLanguageTechnologiesQueryHandler : IRequestHandler<GetLanguageTechnologiesQuery, LanguageTechnologyListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

        public GetLanguageTechnologiesQueryHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
        }

        public async Task<LanguageTechnologyListModel> Handle(GetLanguageTechnologiesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageTechnology> languageTechnologyList = await _languageTechnologyRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            LanguageTechnologyListModel returnItem = _mapper.Map<LanguageTechnologyListModel>(languageTechnologyList);

            return returnItem;
        }
    }
}
