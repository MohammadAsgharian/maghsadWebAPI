using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using maghsadAPI.Repository;
using maghsadAPI.Models.Identity;
using maghsadAPI.Specification;
using maghsadAPI.Helper;

namespace maghsadAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null) return Unauthorized();
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized();

            return null;
        }
    }
}