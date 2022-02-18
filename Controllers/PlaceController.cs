using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using maghsadAPI.Repository;
using maghsadAPI.Models;


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
        public async Task<ActionResult<Models.Place>> GetPlace()
        {
            return Ok(await _placeRepository.GetListAsync());
        }
        [Route("placetype")]
         public async Task<ActionResult<Models.Place>> GetPlaceType()
        {
            return Ok(await _placetypeRepository.GetListAsync());
        }
    }
}