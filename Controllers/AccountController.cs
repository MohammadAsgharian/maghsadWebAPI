using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using maghsadAPI.Models.Identity;
using maghsadAPI.Infrastructure;

namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login()
        {
           // var user = await _userManager.FindByEmailAsync(loginDto.Email);
            // if(user == null) return Unauthorized();
            
            // var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            // if(!result.Succeeded) return Unauthorized();
            AppUser user = new AppUser{
                Email = "m.asgharian@gmail.com",
                Id = "1",
                UserName ="Mass2007"

            };


            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Username =  user.UserName
            };
        }
    }
}