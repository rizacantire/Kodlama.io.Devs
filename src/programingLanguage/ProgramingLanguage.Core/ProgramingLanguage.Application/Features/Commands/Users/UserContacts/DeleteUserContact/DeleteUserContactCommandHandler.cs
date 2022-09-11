using AutoMapper;
using Core.Security.Entities;
using MediatR;
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

namespace ProgramingLanguage.Application.Features.Commands.Users.UserContacts.DeleteUserContact
{
    public class DeleteUserContactCommandHandler : IRequestHandler<DeleteUserContactCommand, int>

    {
        private readonly IMapper _mapper;
        private readonly IUserContactRepository _repository;
        private readonly UserContactBusinessRules _businessRules;

        public DeleteUserContactCommandHandler(IMapper mapper, IUserContactRepository repository, UserContactBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<int> Handle(DeleteUserContactCommand request, CancellationToken cancellationToken)
        {
            UserContact? checkItem = await _repository.GetAsync(predicate: p => p.Id == request.Id);
            _businessRules.UserContactShouldExistWhenRequested(checkItem);
            await _repository.DeleteAsync(checkItem);
            return checkItem.Id;
        }
    }
}
