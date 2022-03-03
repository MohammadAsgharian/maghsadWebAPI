using System;
using maghsadAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace maghsadAPI.Models.Identity
{
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

        public  ICollection<Place> Places {get; set;} = new List<Place>();
        public  ICollection<PlacePhoto> PlacePhotos {get; set;} = new List<PlacePhoto>();




    }
}