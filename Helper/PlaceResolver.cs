using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Models.Dto;
using maghsadAPI.Models.Identity;

namespace maghsadAPI.Helper
{
    public class PlaceResolver : IValueResolver<Place,PlaceDto, string>
    {
        public string Resolve(Place source,PlaceDto destination, string memeber, ResolutionContext context)
        {

            return "asdas";
        }
    }
}