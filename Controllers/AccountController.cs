using System;
using System.Linq;
using maghsadAPI.Models.Dto;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using maghsadAPI.Infrastructure;
using maghsadAPI.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace maghsadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        
        // [HttpGet("create")]
        // public async Task<ActionResult<bool>> CreateUser()
        // {
          
        //     AppUser appUser = new AppUser
        //     {
        //         SinginDate = DateTime.Now.Date,
        //         UserName = "m.vahid",
        //         Email = "marzieh.vahid@gmail.com",
        //         LastName ="وحید",
        //         FirstName ="مرضیه"
        //     };
            
        //     await _userManager.CreateAsync(appUser,"Rayan@Asgharian.1398");
            
        //      return (await _userManager.AddToRoleAsync(appUser,"Admin")).Succeeded;
        // }

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

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
        
    }
}