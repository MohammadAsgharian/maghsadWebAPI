using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class Province : BaseEntity
    {

        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public bool? Status { get; set; }

        public  ICollection<City> Cities {get; set;} = new List<City>();

    }
}