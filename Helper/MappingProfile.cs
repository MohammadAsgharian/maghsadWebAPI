using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Models.Dto;
using maghsadAPI.Models.Identity;
using maghsadAPI.Data;
using System.Linq;


namespace maghsadAPI.Helper
{
    public class MappingProfile : Profile
    {
        private MaghsadContext _context;
        
        
        public MappingProfile(MaghsadContext context)
        {
            _context = context;
            CreateMap<AppUser, UserDto>(); 
            CreateMap<Place, PlaceDto>()
                .ForMember(d => d.PlaceType , o => o.MapFrom( s=> s.PlaceType.Title))
                .ForMember(d => d.City , o => o.MapFrom( s=> s.City.Title))
                .ForMember(d => d.AttractionType , o => o.MapFrom( s=> s.AttractionType.Title))
                .ForMember(d => d.AppUser , o => o.MapFrom( s=> s.AppUser.FirstName + " " + s.AppUser.LastName))
                .ForMember(d => d.PlacePhoto ,  o => o.MapFrom(model => _context.Set<PlacePhoto>().FirstOrDefault(y => y.PlaceId == model.Id && y.IsCover == true).PhotoName)); 
        }
    }
}