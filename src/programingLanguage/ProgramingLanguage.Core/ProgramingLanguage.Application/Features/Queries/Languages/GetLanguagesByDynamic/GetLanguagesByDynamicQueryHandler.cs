using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguagesByDynamic
{
    public class GetLanguagesByDynamicQueryHandler : IRequestHandler<GetLanguagesByDynamicQuery, LanguageListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;

        public GetLanguagesByDynamicQueryHandler(IMapper mapper, ILanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<LanguageListModel> Handle(GetLanguagesByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> models = await _languageRepository.GetListByDynamicAsync(request.Dynamic,
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
            LanguageListModel mappedModels = _mapper.Map<LanguageListModel>(models);
            return mappedModels;
        }
    }
}