using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Infrastructure;
using maghsadAPI.Specification;

namespace maghsadAPI.Repository.Place
{
    public class PlaceRepository : IPlaceRepository
    {
       private readonly Data.MaghsadContext _context;

        public PlaceRepository(Data.MaghsadContext context)
        {
            _context = context;
        }
        protected IQueryable<Models.Place> ApplySpecification(ISpecification<Models.Place> spec)
        {
            return SpecificationEvaluator<Models.Place>.GetQuery(_context.Set<Models.Place>().AsQueryable(), spec);
        }        
        public async Task<IList<Models.Place>> GetListAsync()
        {
            return await _context.Set<Models.Place>().ToListAsync();
        }

        public async Task<Models.Place> GetEntityWithSpec(ISpecification<Models.Place> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IList<Models.Place>> ListAsync(ISpecification<Models.Place> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
         public async Task<int> CountAsync(ISpecification<Models.Place> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
       public async Task<IList<Models.Place>> GetAttractionBanner(){
           var spec = new PlaceSpecification(new PlaceSpecParams{
               PlaceTypeId = 2
           },true);
           IList<Models.Place> attractions =await ApplySpecification(spec).ToListAsync();
           return attractions;
       }

    }
}