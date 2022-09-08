using MediatR;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Features.Commands.LanguageTechnologyies.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand :UpdateLanguageTechnologyModel, IRequest<LanguageTechnologyViewModel>
    {
    }
}
