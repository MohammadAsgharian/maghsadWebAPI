namespace maghsadAPI.Specification
{
    public  class PlaceSpecification : BaseSpecification<Models.Place>
    {

        public PlaceSpecification()
        {
            AddInclude(x=> x.PlaceType);
        }
    }
}