using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using maghsadAPI.Models.Identity;

namespace maghsadAPI.Models
{
    public class PlacePhoto: BaseEntity
    {
        [Required]
        public string PhotoName { get; set; }
        [Required]
        public long PlaceId { get; set; }

        public Place Place{get; set;}

        [Required]
        public string UserId{get; set;}
        public AppUser AppUser{get; set;}

        [Required]
        [StringLength(50)]
        public string TypeFile { get; set; }

        public bool? Status { get; set; }

        public bool? IsCover { get; set; }

       

    }

}
