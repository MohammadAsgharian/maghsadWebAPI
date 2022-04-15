
namespace maghsadAPI.Specification
{
    public  class PostSpecification : BaseSpecification<Models.Post>
    {

        public PostSpecification(PostSpecParams placeParams)
        {
            AddOrderBy(x => x.Id);
            ApplyPaging(placeParams.PageSize *(placeParams.PageIndex -1 ), placeParams.PageSize);

            if(!string.IsNullOrEmpty(placeParams.Sort))
            {
                switch  (placeParams.Sort)
                {
                    case "TitleAsc":
                        AddOrderBy(p => p.Title);
                        break;
                    default :
                        AddOrderBy(p=> p.Id);
                        break;
                }
            }
        }
         public PostSpecification(long Id): base(x=> x.Id == Id)
        {
            AddInclude(x=> x.PlaceType);
        }
    }
}