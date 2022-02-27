using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using maghsadAPI.Repository;
using maghsadAPI.Models;
using maghsadAPI.Specification;
using maghsadAPI.Helper;


namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IGenericRepository<Place>  _placeRepository;
        private readonly IGenericRepository<PlaceType>  _placetypeRepository;

        public PlaceController(IGenericRepository<Place> placeRepository, IGenericRepository<PlaceType> placetypeRepository)
        {
            _placeRepository = placeRepository;
            _placetypeRepository = placetypeRepository;
        }
        public async Task<ActionResult<Pagination<Models.Place>>> GetPlace([FromQuery]PlaceSpecParams placeParams)
        {
            var spec = new PlaceSpecification(placeParams);
            
            var countSpec = new PlaceWithFiltersSpecification(placeParams);

            var totalItems = await _placeRepository.CountAsync(countSpec);

            var places = await _placeRepository.ListAsync(spec);
            



            return Ok(new Pagination);
        }
        [Route("placetype")]
         public async Task<ActionResult<Models.Place>> GetPlaceType()
        {
            return Ok(await _placetypeRepository.GetListAsync());
        }
    }
}