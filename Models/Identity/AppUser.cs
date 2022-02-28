using Microsoft.AspNetCore.Identity;
using System;

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


    }
}