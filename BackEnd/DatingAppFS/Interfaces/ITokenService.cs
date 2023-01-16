using DatingAppFS.Entity;

namespace DatingAppFS.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);

    }
}
