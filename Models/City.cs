using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class City : BaseEntity
    {

        [Required]
        public string Title { get; set; }
        public string AttractionDescription { get; set; }

        public string CoverPhoto { get; set; }

        public string Lon{get; set;}
        public string Lat{get; set;}
        public string Description{get; set;}

       public long ProvinceID{get; set;}
        public Province Province{get; set;}

        public  ICollection<Place> Places {get; set;} = new List<Place>();
        public  ICollection<Post> Posts {get; set;} = new List<Post>();

    }
}