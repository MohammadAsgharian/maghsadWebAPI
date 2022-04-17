
namespace maghsadAPI.Specification
{
    public  class PlaceSpecification : BaseSpecification<Models.Place>
    {
        public PlaceSpecification(){
            AddInclude(x=> x.PlaceType);
            AddInclude(x=> x.AttractionType);
            AddInclude(x=> x.City);
            AddInclude(x=> x.AppUser);
        }

        public PlaceSpecification(PlaceSpecParams placeParams)
            :base(x =>(!placeParams.PlaceTypeId.HasValue || x.PlaceTypeId == placeParams.PlaceTypeId))
        {
            AddInclude(x=> x.PlaceType);
            AddInclude(x=> x.AttractionType);
            AddInclude(x=> x.City);
            AddInclude(x=> x.AppUser);
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
        public PlaceSpecification(PlaceSpecParams placeParams,bool SetApplyLastData)
            :this(placeParams)
        {
            ApplyLastData(placeParams.Take);
        }
         public PlaceSpecification(long Id): base(x=> x.Id == Id)
        {
            AddInclude(x=> x.PlaceType);
        }
    }
}