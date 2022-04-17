using maghsadAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using maghsadAPI.Specification;

namespace maghsadAPI.Infrastructure
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
           Task<IList<T>> GetListAsync();
          Task<T> GetEntityWithSpec(ISpecification<T> spec);
          Task<IList<T>> ListAsync(ISpecification<T> spec);
          Task<int> CountAsync(ISpecification<T> spec);
    }
}