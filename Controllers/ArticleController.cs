using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using maghsadAPI.Infrastructure;
using maghsadAPI.Models;
using maghsadAPI.Specification;
using maghsadAPI.Helper;
using maghsadAPI.Models.Dto;


namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IGenericRepository<Post>  _articleRepository;
        public ArticleController(IGenericRepository<Post> postRepository
        {
            _articleRepository = postRepository;
        }
        [Route("getarticle")]
        public async Task<ActionResult<Pagination<Models.Post>>> GetArtcile([FromQuery]PlaceSpecParams placeParams)
        {
            var spec = new PlaceSpecification(placeParams);
            
            var countSpec = new PlaceWithFiltersSpecification(placeParams);
            



            return Ok("placeParams");
        }

        
         
        
    }
}