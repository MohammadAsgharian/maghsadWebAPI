using maghsadAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using maghsadAPI.Specification;

namespace maghsadAPI.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
          Task<IReadOnlyList<T>> GetListAsync();
          Task<T> GetEntityWithSpec(ISpecification<T> spec);
          Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}