using System.Collections.Generic;

namespace maghsadAPI.Models.Dto
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Username{get; set;}
        public string Token{get; set;}
        public List<string> Roles{get; set;}= new List<string>();
    }
}