namespace maghsadAPI.Specification
{
     public  class PlaceWithFiltersSpecification : BaseSpecification<Models.Place>
    
    {
        public PlaceWithFiltersSpecification(PlaceSpecParams placeParams) 
            :base(x =>(!placeParams.PlaceTypeId.HasValue || x.PlaceTypeId == placeParams.PlaceTypeId))
        {
            
        }
        
    }
}