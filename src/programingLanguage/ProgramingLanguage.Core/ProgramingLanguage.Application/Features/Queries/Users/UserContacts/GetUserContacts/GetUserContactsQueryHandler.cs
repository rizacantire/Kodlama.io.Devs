using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.Users.UserContacts;
using ProgramingLanguage.Application.Repositories.ProgramingLanguages;
using ProgramingLanguage.Application.Repositories.UserContacts;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Features.Queries.Users.UserContacts.GetUserContacts
{
    public class GetUserContactsQueryHandler : IRequestHandler<GetUserContactsQuery, UserContactListModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserContactRepository _repository;

        public GetUserContactsQueryHandler(IMapper mapper, IUserContactRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserContactListModel> Handle(GetUserContactsQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserContact> returnList = await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,include:p=>p.Include(c=>c.User));

            UserContactListModel returnItem = _mapper.Map<UserContactListModel>(returnList);

            return returnItem;
        }
    }
}
