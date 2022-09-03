using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguages
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, LanguageListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;

        public GetLanguagesQueryHandler(IMapper mapper, ILanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<LanguageListModel> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languageList = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            LanguageListModel returnItem = _mapper.Map<LanguageListModel>(languageList);

            return returnItem;
        }
    }
}
