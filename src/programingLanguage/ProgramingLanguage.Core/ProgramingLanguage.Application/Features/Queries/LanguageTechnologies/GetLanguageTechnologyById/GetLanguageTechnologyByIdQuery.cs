using Core.Application.Requests;
using MediatR;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Features.Queries.LanguageTechnologies.GetLanguageTechnologies
{
    public class GetLanguageTechnologyByIdQuery : IRequest<LanguageTechnologyViewModel>
    {
        public int Id { get; set; }

    }
}
