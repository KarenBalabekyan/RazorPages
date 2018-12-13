using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Entities.EntityDbConfigurations
{
    public class ProductDbConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(u => u.DateCreated).HasDefaultValue(DateTime.UtcNow);

            builder
                .HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(u => new {u.Category, u.DateCreated});
        }

        public static async Task SeedDefaultValues(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Products.AnyAsync())
            {
                for (var i = 1; i < 20; i++)
                {
                    await AutoGenerateProductsForTest(dbContext, i);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task AutoGenerateProductsForTest(ApplicationDbContext dbContext, int i)
        {
            var product = new Product
            {
                Name = $"Test product {i}",
                CategoryId = 1,
                Description = $"Product test description {i}",
                Price = 10M * i,
                Images = new List<Image>
                {
                    new Image {Name = $"img{i++}.jpg", SortOrder = 1},
                    new Image {Name = $"img{i++}.jpg", SortOrder = 2},
                    new Image {Name = $"img{i++}.jpg", SortOrder = 3},
                    new Image {Name = $"img{i++}.jpg", SortOrder = 4}
                }
            };

            await dbContext.AddRangeAsync(product);
        }
    }
}