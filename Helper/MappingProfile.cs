using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Models.Dto;
using maghsadAPI.Models.Identity;

namespace maghsadAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>(); 
            CreateMap<Place, PlaceDto>()
                .ForMember(d => d.PlaceType , o => o.MapFrom( s=> s.PlaceType.Title))
                .ForMember(d => d.City , o => o.MapFrom( s=> s.City.Title))
                .ForMember(d => d.AttractionType , o => o.MapFrom( s=> s.AttractionType.Title))
                .ForMember(d => d.AppUser , o => o.MapFrom( s=> s.AppUser.FirstName + " " + s.AppUser.LastName)); 
        }
    }
}