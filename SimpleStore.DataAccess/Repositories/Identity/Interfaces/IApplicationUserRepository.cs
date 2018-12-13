using Microsoft.AspNetCore.Identity;
using SimpleStore.DataAccess.Entities.Identity;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories.Identity.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password, string roleName);

        Task<IdentityResult> EditAsync(ApplicationUser user);

        Task<IdentityResult> RemoveAsync(ApplicationUser user);

        Task<ApplicationUser> FindUserByNameAsync(string userName);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task<ApplicationUser> FindUserByIdAsync(string id);

        Task<bool> SignIn(string userName, string password);
    }
}
