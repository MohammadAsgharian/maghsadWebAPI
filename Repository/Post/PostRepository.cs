using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace maghsadAPI.Repository.Place
{
    public class PostRepository : IPostRepository
    {

        private readonly maghsadAPI.Data.MaghsadContext _context;
        public PlaceRepository(Data.MaghsadContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Models.Post>> GetPostAsync()
        {
            return await _context.Posts.ToListAsync();
        }

    }
}