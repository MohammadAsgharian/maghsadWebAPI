using AutoMapper;
using maghsadAPI.Models;
using maghsadAPI.Helper;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using maghsadAPI.Specification;
using Microsoft.AspNetCore.Mvc;
using maghsadAPI.Infrastructure;
using System.Collections.Generic;




namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IGenericRepository<Place>  _placeRepository;
        private readonly IGenericRepository<PlaceType>  _placetypeRepository;
        private readonly IMapper _mapper;
        public PlaceController(IGenericRepository<Place> placeRepository, IGenericRepository<PlaceType> placetypeRepository, IMapper mapper)
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
            var countSpec = new PlaceWithFiltersSpecification(placeParams);
            var totalItems = await _placeRepository.CountAsync(countSpec);
            var places = await _placeRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Place>, IReadOnlyList<PlaceDto>>(places));
        }
         [Route("lastplace")]
        public async Task<ActionResult<Pagination<Models.Dto.PlaceDto>>> GetPlace()
        {
            var spec = new PlaceSpecification(new PlaceSpecParams{
                PageIndex = 1,
                PageSize = 15
            });
            var places = await _placeRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Place>, IReadOnlyList<PlaceDto>>(places));
        }

        
         
        [Route("placetype")]
         public async Task<ActionResult<Models.Place>> GetPlaceType()
        {
            return Ok(await _placetypeRepository.GetListAsync());
        }
    }
}