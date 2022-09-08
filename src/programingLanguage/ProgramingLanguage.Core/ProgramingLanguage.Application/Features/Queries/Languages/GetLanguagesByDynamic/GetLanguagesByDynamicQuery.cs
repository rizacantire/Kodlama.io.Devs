using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguagesByDynamic
{
    public class GetLanguagesByDynamicQuery : IRequest<LanguageListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
    }
}