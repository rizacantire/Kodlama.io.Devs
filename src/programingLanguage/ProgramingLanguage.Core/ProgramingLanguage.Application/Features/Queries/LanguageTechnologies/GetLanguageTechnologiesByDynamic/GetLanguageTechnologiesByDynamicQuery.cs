using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.LanguageTechnologyis;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguageTechnologiesByDynamic
{
    public class GetLanguageTechnologiesByDynamicQuery : IRequest<LanguageTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}