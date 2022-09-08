using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;

namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologies.AddLanguageTechnology
{
    public class AddLanguageTechnologyCommand : AddLanguageModel,IRequest<LanguageTechnologyViewModel>
    {
    }
}
