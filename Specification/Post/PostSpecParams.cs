namespace maghsadAPI.Specification
{
    public class PostSpecParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 15;
        public string Sort{get; set;}
    }
}
