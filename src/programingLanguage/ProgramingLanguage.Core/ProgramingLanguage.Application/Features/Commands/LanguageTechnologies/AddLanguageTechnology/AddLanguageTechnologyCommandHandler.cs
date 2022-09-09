using AutoMapper;
using MediatR;
using ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage;
using ProgramingLanguage.Application.Models.LanguageTechnologies;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Domain.Entities;
using ProgramingLanguage.Application.Rules.LanguageTechnologies;

namespace ProgramingLanguage.Application.Features.Commands.LanguageTechnologies.AddLanguageTechnology
{
    public class AddLanguageTechnologyCommandHandler : IRequestHandler<AddLanguageTechnologyCommand, LanguageTechnologyViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;

        public AddLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageTechnologyRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<LanguageTechnologyViewModel> Handle(AddLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _languageTechnologyBusinessRules.LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

            LanguageTechnology languageTechnologyEntity = _mapper.Map<LanguageTechnology>(request);
            LanguageTechnology result = await _languageTechnologyRepository.AddAsync(languageTechnologyEntity);
            LanguageTechnologyViewModel returnItem = _mapper.Map<LanguageTechnologyViewModel>(result);

            return returnItem;

        }
    }
}
