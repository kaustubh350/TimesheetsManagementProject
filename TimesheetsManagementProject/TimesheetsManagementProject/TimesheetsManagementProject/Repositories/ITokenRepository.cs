using Microsoft.AspNetCore.Identity;

namespace TimesheetsManagementProject.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
