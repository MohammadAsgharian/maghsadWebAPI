using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace maghsadAPI.Models
{
    public class User: BaseEntity
    {

        public long UserLevelID { get; set; }
        public UserLevel UserLevel{get; set;}

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(50)]
        public string InstagramName { get; set; }

        public int? ActivationCodeEmail { get; set; }

        public int? ActivateSms { get; set; }

        public bool? EmailConfirmed { get; set; }

        [MaxLength(50)]
        public byte[] Password { get; set; }
        
        public string AvatarPhotoName { get; set; }

        public DateTime SinginDate { get; set; }

        public string CoverPhotoName { get; set; }

        public long? YourEarn { get; set; }

        public  ICollection<PlacePhoto> PlacePhotos {get; set;} = new List<PlacePhoto>();
    }
}