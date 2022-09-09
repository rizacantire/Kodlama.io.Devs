using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.LanguageTechnologyis;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguageTechnologiesByDynamic
{
    public class GetLanguageTechnologiesByDynamicHandler : IRequestHandler<GetLanguageTechnologiesByDynamicQuery, LanguageTechnologyListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

        public GetLanguageTechnologiesByDynamicHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
        }

        public async Task<LanguageTechnologyListModel> Handle(GetLanguageTechnologiesByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageTechnology> models = await _languageTechnologyRepository.GetListByDynamicAsync(request.Dynamic,
                                                include: p => p.Include(c=>c.Language),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );
            LanguageTechnologyListModel mappedModels = _mapper.Map<LanguageTechnologyListModel>(models);
            return mappedModels;
        }
    }
}