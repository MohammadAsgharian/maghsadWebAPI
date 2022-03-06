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
        }
    }
}