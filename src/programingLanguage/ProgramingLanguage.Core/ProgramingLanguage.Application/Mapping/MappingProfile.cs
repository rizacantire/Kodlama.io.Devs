using AutoMapper;
using Core.Persistence.Paging;
using ProgramingLanguage.Application.Features.Commands.Languages.AddLanguage;
using ProgramingLanguage.Application.Features.Commands.Languages.UpdateLanguage;
using ProgramingLanguage.Application.Models.Languages;
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
            
            CreateMap<Language, AddLanguageCommand>().ReverseMap();
            CreateMap<UpdateLanguageCommand, Language>().ReverseMap();
            CreateMap<UpdateLanguageCommand, LanguageViewModel>().ReverseMap();
            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<AddLanguageModel, AddLanguageCommand>().ReverseMap();
            CreateMap<LanguageViewModel, AddLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();

        }
    }
}
