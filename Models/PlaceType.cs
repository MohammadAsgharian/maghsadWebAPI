using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class PlaceType : BaseEntity
    {

        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public bool? Status { get; set; }

        public  ICollection<Place> Places {get; set;} = new List<Place>();
    }
}