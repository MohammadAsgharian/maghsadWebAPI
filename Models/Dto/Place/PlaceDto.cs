namespace maghsadAPI.Models.Dto
{
    public class PlaceDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Lon { get; set; }
        public string Lat { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Site { get; set; }
        public string Instagram { get; set; }
        public string Description { get; set; }
        public int? grade { get; set; }
        public bool? Status { get; set; }
        public string PlaceType{get; set;}
        public string City{get; set;}
        public string AttractionType{get; set;}
        public string AppUser{get; set;}
        public string PlacePhoto{get; set;}
    }
}