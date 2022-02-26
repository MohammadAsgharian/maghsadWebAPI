using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class Place : BaseEntity
    {

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Lon { get; set; }

        [Required]
        [StringLength(50)]
        public string Lat { get; set; }
        
        public string Address { get; set; }
        
        [StringLength(200)]
        public string Tel { get; set; }

        [StringLength(200)]
        public string Site { get; set; }

        [StringLength(200)]
        public string Instagram { get; set; }

        public string Description { get; set; }

        public int? grade { get; set; }
        public bool? Status { get; set; }
        public int? PriceType { get; set; }

        public long PlaceTypeID{get; set;}
        public PlaceType PlaceType{get; set;}

        public long CityID{get; set;}
        public City City{get; set;}
        

        public  ICollection<PlacePhoto> PlacePhotos {get; set;} = new List<PlacePhoto>();

    }
}