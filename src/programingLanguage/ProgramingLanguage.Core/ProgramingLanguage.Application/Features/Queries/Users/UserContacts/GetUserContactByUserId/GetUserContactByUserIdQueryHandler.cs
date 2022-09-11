using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

namespace ProgramingLanguage.Application.Features.Queries.Users.UserContacts.GetUserContactByUserId
{
    public class GetUserContactByUserIdQueryHandler : IRequestHandler<GetUserContactByUserIdQuery, UserContactViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserContactRepository _repository;
        private readonly UserContactBusinessRules _businessRules;

        public GetUserContactByUserIdQueryHandler(IMapper mapper, IUserContactRepository repository, UserContactBusinessRules businessRules)
        {
            _mapper = mapper;
            _repository = repository;
            _businessRules = businessRules;
        }

        public async Task<UserContactViewModel> Handle(GetUserContactByUserIdQuery request, CancellationToken cancellationToken)
        {
            UserContact? checkItem = await _repository.GetAsync(predicate:p=>p.UserId == request.UserId,include:p=>p.Include(c=>c.User));
            _businessRules.UserContactShouldExistWhenRequested(checkItem);
            
            UserContactViewModel returnItem = _mapper.Map<UserContactViewModel>(checkItem);

            return returnItem;
        }
    }
}
