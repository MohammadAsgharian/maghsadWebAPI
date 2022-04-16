using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Infrastructure;
using maghsadAPI.Specification;


namespace maghsadAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly Data.MaghsadContext _context;

        public GenericRepository(Data.MaghsadContext context)
        {
            _context = context;
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
        

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
         public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

    }
}