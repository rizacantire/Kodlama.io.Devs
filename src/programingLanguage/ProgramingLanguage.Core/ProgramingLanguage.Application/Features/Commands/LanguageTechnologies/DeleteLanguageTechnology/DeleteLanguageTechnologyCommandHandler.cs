using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguage.Application.Rules.LanguageTechnologies;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologyies.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;

        public DeleteLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<bool> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology? languageTechnology = await _languageTechnologyRepository.GetAsync(predicate: p => p.Id == request.Id);
            _languageTechnologyBusinessRules.LanguageTechnologyShouldExistWhenRequested(languageTechnology);
            await _languageTechnologyRepository.DeleteAsync(languageTechnology);
            return true;
        }
    }
}
