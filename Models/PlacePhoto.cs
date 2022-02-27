using System.ComponentModel.DataAnnotation;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class PlacePhoto: BaseEntity
    {
        [Required]
        public string PhotoName { get; set; }

        public long PlaceID { get; set; }

        public Place Place{get; set;}

        public long UserID { get; set; }
        public User User{get; set;}

        [Required]
        [StringLength(50)]
        public string TypeFile { get; set; }

        public bool? Status { get; set; }

        public bool? IsCover { get; set; }

        public  ICollection<PlacePhoto> PlacePhotos {get; set;} = new List<PlacePhoto>();

    }

}
