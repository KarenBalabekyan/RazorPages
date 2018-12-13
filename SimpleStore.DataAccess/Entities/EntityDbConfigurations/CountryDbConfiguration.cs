using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.DataAccess.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Entities.EntityDbConfigurations
{
    public class CountryDbConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasAlternateKey(u => u.Name);
        }

        public static async Task SeedDefaultValues(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Countries.AnyAsync())
            {
                var countries = new List<Country>
                {
                    new Country {Name = "Armenia"},
                    new Country {Name = "Russian Federation"},
                    new Country {Name = "USA"}
                };

                await dbContext.AddRangeAsync(countries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}