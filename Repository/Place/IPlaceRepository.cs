using System.Threading.Tasks;
using System.Collections.Generic;

namespace maghsadAPI.Repository.Place
{
    public interface IPlaceRepository
    {
        Task<IReadOnlyList<Models.Place>> GetPlaceAsync();
    }
}