using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Models.Dto;
using Microsoft.Extensions.Configuration;

namespace maghsadAPI.Helper
{
    

   

    public class PlaceResolver : IValueResolver<Place,PlaceDto, string>
    {
        private readonly IConfiguration _config;
         public PlaceResolver(IConfiguration config)
        {
            _config = config;
        }

        
    }
}