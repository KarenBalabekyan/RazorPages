using Microsoft.AspNetCore.Identity;
using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Entities.Identity;
using SimpleStore.DataAccess.Repositories.Identity.Interfaces;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories.Identity
{
    public class ApplicationRoleRepository : IApplicationRoleRepository
    {
        //private readonly RoleStore<ApplicationRole> _roleStore;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationRoleRepository(ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(ApplicationRole applicationRole)
        {
            var isExists = !string.IsNullOrEmpty(applicationRole.Id) &&
                           await _roleManager.RoleExistsAsync(applicationRole.Name);

            var result = isExists
                ? await _roleManager.UpdateAsync(applicationRole)
                : await _roleManager.CreateAsync(applicationRole);

            return result;
        }

        public async Task<ApplicationRole> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<IdentityResult> RemoveRoleByNameAsync(ApplicationRole applicationRole)
        {
            return await _roleManager.DeleteAsync(applicationRole);
        }
    }
}