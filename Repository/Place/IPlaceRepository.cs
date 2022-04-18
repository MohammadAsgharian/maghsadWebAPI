using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Infrastructure;
using maghsadAPI.Specification;

namespace maghsadAPI.Repository.Place
{
    public interface IPlaceRepository: IGenericRepository<Models.Place>
    {
      Task<IList<Models.Place>> GetAttractionBanner();
       Task<IList<Models.Dto.PlaceDto>> GetPhotos(IList<Models.Dto.PlaceDto> placeDtos);
    }
}