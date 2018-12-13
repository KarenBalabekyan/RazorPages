using Microsoft.AspNetCore.Identity;
using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Entities.Identity;
using SimpleStore.DataAccess.Repositories.Identity.Interfaces;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Repositories.Identity
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser applicationUser, string password, string roleName)
        {
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (!result.Succeeded)
                return result;

            if (!(await _roleManager.RoleExistsAsync(roleName)))
            {
                return IdentityResult.Failed(new IdentityError() { Description = $"{roleName} does not exists." });
            }

            return await _userManager.AddToRoleAsync(applicationUser, roleName);
        }

        public async Task<IdentityResult> EditAsync(ApplicationUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> RemoveAsync(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> FindUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<bool> SignIn(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, lockoutOnFailure: false);
            return result.Succeeded;
            //if (result.RequiresTwoFactor)
        }
    }
}
