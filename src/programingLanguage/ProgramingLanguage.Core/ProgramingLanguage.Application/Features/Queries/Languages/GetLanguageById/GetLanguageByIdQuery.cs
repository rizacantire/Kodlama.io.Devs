using Core.Application.Requests;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Languages.GetLanguages
{
    public class GetLanguageByIdQuery : IRequest<LanguageViewModel>
    {
        public int Id { get; set; }

    }
}
