using Microsoft.AspNetCore.Identity;
using SimpleStore.DataAccess.DbContexts;
using SimpleStore.DataAccess.Entities.EntityDbConfigurations;
using SimpleStore.DataAccess.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Migrations.DefaultDataSeeder
{
    public class DefaultDataSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DefaultDataSeeder(ApplicationDbContext authContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _dbContext = authContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            //_dbContext.Database.Migrate();

            #region Fill Auth Db

            if (!_dbContext.Roles.Any())
            {
                var roles = new List<ApplicationRole>()
                {
                    new ApplicationRole()
                    {
                        Name = "admin",
                        NormalizedName = "Administrator",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    },
                    new ApplicationRole()
                    {
                        Name = "User",
                        NormalizedName = "User",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                };

                foreach (var role in roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }

            if (!_dbContext.Users.Any())
            {
                //Add new test administrator
                var admin = new ApplicationUser()
                {
                    Email = "admin@SimpleStore.com",
                    UserName = "admin@SimpleStore.com",
                    FullName = "Test Admin",
                    JoinDate = DateTime.Now
                };

                var result = await _userManager.CreateAsync(admin, "Password1!");

                if (result.Succeeded)
                {
                    admin.EmailConfirmed = true;
                    await _userManager.UpdateAsync(admin);
                    var roleName = "Admin";

                    if (await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _userManager.AddToRoleAsync(admin, roleName);
                    }
                }

                //Add new test user
                var user = new ApplicationUser()
                {
                    Email = "user@SimpleStore.com",
                    UserName = "user@SimpleStore.com",
                    FullName = "Test user",
                    JoinDate = DateTime.Now
                };

                result = await _userManager.CreateAsync(admin, "Password2!");

                if (result.Succeeded)
                {
                    admin.EmailConfirmed = true;
                    await _userManager.UpdateAsync(admin);
                    var roleName = "User";

                    if (await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _userManager.AddToRoleAsync(admin, roleName);
                    }
                }
            }

            #endregion

            await CountryDbConfiguration.SeedDefaultValues(_dbContext);
            await CityDbConfiguration.SeedDefaultValues(_dbContext);
            await ProductCategoryDbConfiguration.SeedDefaultValues(_dbContext);
            await ProductCategoryDbConfiguration.SeedDefaultValues(_dbContext);
        }
    }
}