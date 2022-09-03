using MediatR;
using ProgramingLanguage.Application.Models.Languages;

namespace ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage
{
    public class AddLanguageCommand : AddLanguageModel,IRequest<LanguageViewModel>
    {
    }
}
