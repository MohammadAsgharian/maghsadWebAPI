using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using maghsadAPI.Models.Identity;
using maghsadAPI.Infrastructure;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x=> x.Type == ClaimTypes.Email).Value;
            var user =await _userManager.FindByEmailAsync(email);

             return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Username =  user.UserName
            };
        }





        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
           var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null) return Unauthorized();
            
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized();
         


            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Username =  user.UserName
            };
        }
    }
}