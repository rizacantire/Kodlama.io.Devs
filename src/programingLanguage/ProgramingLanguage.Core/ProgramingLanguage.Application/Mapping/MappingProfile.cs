using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage;
using ProgramingLanguage.Application.Features.Commands.Languages.UpdateLanguage;
using ProgramingLanguage.Application.Features.Commands.LanguageTechnologies.AddLanguageTechnology;
using ProgramingLanguage.Application.Features.Commands.LanguageTechnologyies.UpdateLanguageTechnology;
using ProgramingLanguage.Application.Features.Queries.Auths.Login;
using ProgramingLanguage.Application.Models.Languages;
using ProgramingLanguage.Application.Models.LanguageTechnologies;
using ProgramingLanguage.Application.Models.LanguageTechnologyis;
using ProgramingLanguage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingLanguage.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region  Language
            CreateMap<Language, AddLanguageCommand>().ReverseMap();
            CreateMap<UpdateLanguageCommand, Language>().ReverseMap();
            CreateMap<UpdateLanguageCommand, LanguageViewModel>().ReverseMap();
            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<AddLanguageModel, AddLanguageCommand>().ReverseMap();
            CreateMap<LanguageViewModel, AddLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            #endregion

            #region LanguageTechnology
            CreateMap<LanguageTechnology, AddLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyViewModel>().ReverseMap();
            CreateMap<AddLanguageTechnologyModel, AddLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnologyViewModel, AddLanguageTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
            CreateMap<UpdateLanguageTechnologyCommand, LanguageTechnology>().ReverseMap();
            CreateMap<UpdateLanguageTechnologyCommand, LanguageTechnologyViewModel>().ReverseMap();
            #endregion

            #region  Login
            CreateMap<LoginQuery,UserForLoginDto>().ReverseMap();
            #endregion
        }
    }
}
