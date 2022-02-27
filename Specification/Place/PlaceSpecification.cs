using System;
using System.Linq.Expressions;
using maghsadAPI.Models;


namespace maghsadAPI.Specification
{
    public  class PlaceSpecification : BaseSpecification<Models.Place>
    {

        public PlaceSpecification(string sort)
        {
            AddInclude(x=> x.PlaceType);

            if(!string.IsNullOrEmpty(sort))
            {
                switch  (sort)
                {
                    case "TitleAsc":
                        AddOrderBy(p => p.Title);
                        break;
                    default :
                        AddOrderBy(p=> p.Title);
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