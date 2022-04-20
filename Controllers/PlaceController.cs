using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Helper;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using maghsadAPI.Specification;
using maghsadAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using maghsadAPI.Infrastructure;
using maghsadAPI.Repository.Place;
using System.Collections.Generic;




namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly  IPlaceRepository _placeRepository;
        private readonly IGenericRepository<PlaceType>  _placetypeRepository;
        private readonly IMapper _mapper;
        public PlaceController(IPlaceRepository placeRepository, IGenericRepository<PlaceType> placetypeRepository, IMapper mapper)
        {
            _placeRepository = placeRepository;
            _placetypeRepository = placetypeRepository;
            _mapper = mapper;
        }

        [Route("placebyfilter")]
        [HttpPost]
        public async Task<ActionResult<Pagination<Models.Dto.PlaceDto>>> GetPlace(PlaceSpecParams placeParams)
        {
            var spec = new PlaceSpecification(placeParams);
            var totalItems = await _placeRepository.CountAsync(spec);
            var places = await _placeRepository.ListAsync(spec);

            return Ok(_mapper.Map<IList<Place>, IList<PlaceDto>>(places));
        }
         [Route("getbannerattraction")]
        public async Task<ActionResult<Pagination<Models.Dto.PlaceDto>>> GetBannerAttraction()
        {
           
            var places = await _placeRepository.GetAttractionBanner();
            IList<PlaceDto> placesdtos = _mapper.Map<IList<Place>, IList<PlaceDto>>(places);
          //  placesdtos =await _placeRepository.GetPhotos(placesdtos);

            return Ok(placesdtos);
        }

        
         
        [Route("placetype")]
         public async Task<ActionResult<Models.Place>> GetPlaceType()
        {
            return Ok(await _placetypeRepository.GetListAsync());
        }
    }
}