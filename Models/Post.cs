using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using maghsadAPI.Models.Identity;

namespace maghsadAPI.Models
{
    public class Post : BaseEntity
    {

        [Required]
        public string Title { get; set; }
        public string SummaryTitle { get; set; }

        public string CoverPhoto { get; set; }



        public string UserId{get; set;}
        public AppUser AppUser{get; set;}
        public long? CityId{get; set;}
        public City  City{get; set;}
        public DateTime Date{get; set;}
        public TimeSpan Time{get; set;}
        public bool Status{get; set;}
        public DateTime LastUpdateDate{get; set;}
        public int CountVisit{get; set;}
        public string TypeFile{get; set;}

    }
}