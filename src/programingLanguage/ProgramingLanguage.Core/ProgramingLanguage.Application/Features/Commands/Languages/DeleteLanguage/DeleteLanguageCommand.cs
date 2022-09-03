using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Rules.Languages;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Languages.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
