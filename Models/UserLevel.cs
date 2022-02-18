using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class UserLevel : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public bool? Status { get; set; }

        public  ICollection<User> Users {get; set;} = new List<User>();
    }
}