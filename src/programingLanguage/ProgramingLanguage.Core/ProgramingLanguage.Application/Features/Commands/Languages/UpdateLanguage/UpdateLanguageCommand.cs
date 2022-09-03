using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Languages.UpdateLanguage
{
    public class UpdateLanguageCommand :UpdateLanguageModel, IRequest<LanguageViewModel>
    {
    }
}
