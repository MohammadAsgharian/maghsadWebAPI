using System;
using System.Linq.Expressions;
using maghsadAPI.Models;


namespace maghsadAPI.Specification
{
    public  class PlaceSpecification : BaseSpecification<Models.Place>
    {

        public PlaceSpecification()
        {
            AddInclude(x=> x.PlaceType);
        }
         public PlaceSpecification(long Id): base(x=> x.Id == Id)
        {
            AddInclude(x=> x.PlaceType);
        }
    }
}