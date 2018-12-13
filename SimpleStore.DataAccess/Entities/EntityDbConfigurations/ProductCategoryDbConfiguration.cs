using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Entities.EntityDbConfigurations
{
    public class ProductCategoryDbConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasAlternateKey(u => u.Name);
        }

        public static async Task SeedDefaultValues(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Countries.AnyAsync())
            {
                var countries = new List<ProductCategory>
                {
                    new ProductCategory {Name = "Organic Products"},
                    new ProductCategory {Name = "Meat Products"},
                    new ProductCategory {Name = "Fish and Seafood"},
                    new ProductCategory {Name = "Frozen Products"},
                    new ProductCategory {Name = "Sweets"}
                };

                await dbContext.AddRangeAsync(countries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}