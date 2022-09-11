using AutoMapper;
using Core.Security.Entities;
using MediatR;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.UserContacts;
using ProgramingLanguage.Application.Rules.Languages;
using ProgramingLanguage.Application.Rules.UserContacts;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Commands.Users.UserContacts.UpdateUserContact
{
    public class UpdateUserContactCommandHandler : IRequestHandler<UpdateUserContactCommand, UserContactViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserContactRepository _repository;
        private readonly UserContactBusinessRules _businessRules;

        public UpdateUserContactCommandHandler(IMapper mapper, IUserContactRepository repository, UserContactBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }


        public async Task<UserContactViewModel> Handle(UpdateUserContactCommand request, CancellationToken cancellationToken)
        {
            UserContact? chekcItem = await _repository.GetByIdAsync(request.Id);
            _businessRules.UserContactShouldExistWhenRequested(chekcItem);

            await _businessRules.UserContactCanNotBeDuplicatedWhenInserted(request.GitHubAddress);
            _mapper.Map(request, chekcItem);
            var updateItem = await _repository.UpdateAsync(chekcItem);
            var returnItem = _mapper.Map<UserContactViewModel>(updateItem);

            return returnItem;
        }
    }
}
