using System.Threading.Tasks;
using System.Collections.Generic;

namespace maghsadAPI.Repository.Post
{
    public interface IPostRepository
    {
        Task<IReadOnlyList<Models.Post>> GetPostAsync();
    }
}