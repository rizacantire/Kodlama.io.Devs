using MediatR;
using ProgramingLanguage.Application.Models.LanguageTechnologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologyies.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand :UpdateLanguageTechnologyModel, IRequest<LanguageTechnologyViewModel>
    {
    }
}
