using maghsadAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace maghsadAPI.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
          Task<IReadOnlyList<T>> GetListAsync();
    }
}