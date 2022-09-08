using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguageTechnology.Application.Models.LanguageTechnologies;
using ProgramingLanguageTechnology.Application.Rules.LanguageTechnologies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguageTechnology.Application.Features.Commands.LanguageTechnologyies.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, LanguageTechnologyViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;

        public UpdateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<LanguageTechnologyViewModel> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology? languageTechnology = await _languageTechnologyRepository.GetByIdAsync(request.Id);
            _languageTechnologyBusinessRules.LanguageTechnologyShouldExistWhenRequested(languageTechnology);

            await _languageTechnologyBusinessRules.LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
            _mapper.Map(request, languageTechnology);
            var updateItem = await _languageTechnologyRepository.UpdateAsync(languageTechnology);
            var returnItem = _mapper.Map<LanguageTechnologyViewModel>(updateItem);

            return returnItem;
        }
    }
}
