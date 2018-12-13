using Microsoft.AspNetCore.Identity;
using SimpleStore.DataAccess.Entities.Identity;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories.Identity.Interfaces
{
    public interface IApplicationRoleRepository
    {
        Task<IdentityResult> CreateRoleAsync(ApplicationRole applicationRole);
        Task<ApplicationRole> GetRoleByNameAsync(string roleName);
        Task<IdentityResult> RemoveRoleByNameAsync(ApplicationRole applicationRole);
    }
}