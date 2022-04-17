namespace maghsadAPI.Specification
{
    public class PlaceSpecParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public int Take {get; set;} = 15;
        public string Sort{get; set;}
        
        public long? PlaceTypeId{get; set;}
    }
}
