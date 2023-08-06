using Application.Features.Language.Dtos;
using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateLanguageCommand, Domain.Entities.Language>().ReverseMap();
            CreateMap<CreateLanguageDto, Domain.Entities.Language>().ReverseMap();

            CreateMap<DeleteLanguageCommand, Domain.Entities.Language>().ReverseMap();
            CreateMap<DeleteLanguageDto, Domain.Entities.Language>().ReverseMap();

            CreateMap<UpdateLanguageCommand, Domain.Entities.Language>().ReverseMap();
            CreateMap<UpdateLanguageDto, Domain.Entities.Language>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Language>, GetListModel>().ReverseMap();
            CreateMap<Domain.Entities.Language, GetListLanguageDto>().ReverseMap();

            CreateMap<Domain.Entities.Language,GetByIdDto>().ReverseMap();

        }
    }
}
