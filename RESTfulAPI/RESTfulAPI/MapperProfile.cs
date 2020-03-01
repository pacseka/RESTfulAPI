using AutoMapper;
using RESTfulAPI.Dto;
using RESTfulAPI.DTO;
using RESTfulAPI.Infrastructure.Models;

namespace RESTfulAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sword, SwordDto>()
                .ReverseMap();

            CreateMap<BlackSmith, BlackSmithDto>()
                .ReverseMap();

            CreateMap<UpsertSword, SwordDto>();

            CreateMap<IBlackSmithUpdate, BlackSmith>()
                .ForMember(dest => dest.Id, cfg => cfg.Ignore());

            CreateMap<ISwordUpdate, Sword>()
                .ForMember(dest => dest.Id, cfg => cfg.Ignore());
        }


    }
}
