using System.Collections.Generic;
using System.Linq;
using maghsadAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maghsadAPI.Infrastructure;
using maghsadAPI.Specification;
using Microsoft.Extensions.Configuration;

namespace maghsadAPI.Repository.Place
{


    public class PlaceRepository : IPlaceRepository
    {
        private IConfiguration Configuration { get; }
        private readonly Data.MaghsadContext _context;


        public PlaceRepository(Data.MaghsadContext context, IConfiguration configuration)
        {
            _context = context;
             Configuration = configuration;
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
               PlaceTypeId = 3,
           },true);
           IList<Models.Place> attractions =await ApplySpecification(spec).ToListAsync();
           return attractions;
       }
        public async Task<IList<Models.Dto.PlaceDto>> GetPhotos(IList<Models.Dto.PlaceDto> placeDtos){

          IList<Models.Dto.PlaceDto> result=
            new List<Models.Dto.PlaceDto>();
           
           placeDtos.ToList()
                .ForEach( x=>
                    {
                        Models.PlacePhoto placePhoto = _context.Set<Models.PlacePhoto>().FirstOrDefault(y => y.PlaceId==x.Id && y.IsCover==true);
                        x.PlacePhoto =Configuration["PlacePhoto"]+ x.Id.ToString()+"/" + x.Id.ToString() + "-" + placePhoto.Id.ToString() + placePhoto.TypeFile;
                        result.Add(x);

                    } )  ;


           return result;
       }

    }
}