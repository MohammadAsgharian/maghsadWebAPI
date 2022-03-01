using maghsadAPI.Models.Identity;

namespace maghsadAPI.Infrastructure
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}