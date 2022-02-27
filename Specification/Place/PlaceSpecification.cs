namespace maghsadAPI.Specification
{
    public  class PlaceSpecification : BaseSpecification<Models.Place>
    {

        public PlaceSpecification(PlaceSpecParams placeParams)
        {
            AddInclude(x=> x.PlaceType);
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
         public PlaceSpecification(long Id): base(x=> x.Id == Id)
        {
            AddInclude(x=> x.PlaceType);
        }
    }
}