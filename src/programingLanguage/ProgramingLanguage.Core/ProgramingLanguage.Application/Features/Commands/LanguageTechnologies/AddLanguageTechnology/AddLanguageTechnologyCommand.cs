using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.LanguageTechnologies;

namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologies.AddLanguageTechnology
{
    public class AddLanguageTechnologyCommand : AddLanguageTechnologyModel,IRequest<LanguageTechnologyViewModel>
    {
    }
}
