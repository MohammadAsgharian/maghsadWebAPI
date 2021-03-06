using System;
using maghsadAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace maghsadAPI.Models.Identity
{
    [Table("AspNetUsers")]
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string InstagramName { get; set; }
        public int? ActivateSms { get; set; }
        public string AvatarPhotoName { get; set; }

        public DateTime SinginDate { get; set; }

        public string CoverPhotoName { get; set; }

        [NotMapped]
        public string Token {get; set;}

        [NotMapped]
        public List<string> Roles {get; set;} = new List<string>();

        public  ICollection<Place> Places {get; set;} = new List<Place>();
        public  ICollection<PlacePhoto> PlacePhotos {get; set;} = new List<PlacePhoto>();
        public  ICollection<Post> Posts {get; set;} = new List<Post>();



    }
}