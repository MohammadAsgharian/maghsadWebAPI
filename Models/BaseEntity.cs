using System.ComponentModel.DataAnnotations;

namespace maghsadAPI.Models

{
    public class BaseEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }

    }
}