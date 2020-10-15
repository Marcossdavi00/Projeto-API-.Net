using System.Linq;
using API.Dtos;
using AutoMapper;
using Domain;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //Associação de mapeamento, referenciando a entidade PalestranteEvent
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventDtos>()
            .ForMember(dest => dest.Palestrantes, opt =>{
                opt.MapFrom(src => src.PalestrantesEvents.Select(x => x.Palestrantes).ToList());
            }).ReverseMap();
            CreateMap<Palestrante, PalestranteDtos>()
            .ForMember(dest => dest.Events, opt =>{
                opt.MapFrom(src => src.PalestrantesEvents.Select(x => x.Events).ToList());
            }).ReverseMap();
            CreateMap<Lote, LoteDtos>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDtos>().ReverseMap();
        }
    }
}