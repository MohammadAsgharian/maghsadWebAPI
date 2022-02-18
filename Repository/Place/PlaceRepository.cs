using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace maghsadAPI.Repository.Place
{
    public class PlaceRepository : IPlaceRepository
    {

        private readonly maghsadAPI.Data.MaghsadContext _context;
        public PlaceRepository(Data.MaghsadContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Models.Place>> GetPlaceAsync()
        {
            return await _context.Places.ToListAsync();
        }
    }
}