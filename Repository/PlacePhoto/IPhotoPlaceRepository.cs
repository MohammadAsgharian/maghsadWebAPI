using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Infrastructure;
using maghsadAPI.Specification;

namespace maghsadAPI.Repository.Place
{
    public interface IPhotoPlaceRepository: IGenericRepository<Models.Place>
    {
    }
}