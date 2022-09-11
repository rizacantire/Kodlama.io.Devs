using AutoMapper;
using Core.Security.Entities;
using MediatR;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.UserContacts;
using ProgramingLanguage.Application.Rules.UserContacts;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Users.UserContacts.AddUserContact
{
    public class AddUserContactCommandHandler : IRequestHandler<AddUserContactCommand, UserContactViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserContactRepository _userContactRepository;
        private readonly UserContactBusinessRules _businessRules;

        public AddUserContactCommandHandler(IMapper mapper, IUserContactRepository userContactRepository, UserContactBusinessRules businessRules)
        {
            _mapper = mapper;
            _userContactRepository = userContactRepository;
            _businessRules = businessRules;
        }

        public async Task<UserContactViewModel> Handle(AddUserContactCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.UserContactCanNotBeDuplicatedWhenInserted(request.GitHubAddress);

            UserContact userContactEntity = _mapper.Map<UserContact>(request);
            UserContact result = await _userContactRepository.AddAsync(userContactEntity);
            UserContactViewModel returnItem = _mapper.Map<UserContactViewModel>(result);

            return returnItem;
        }
    }
}
