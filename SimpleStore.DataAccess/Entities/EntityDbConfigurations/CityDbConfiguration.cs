using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStore.DataAccess.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStore.DataAccess.Entities.EntityDbConfigurations
{
    public class CityDbConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasAlternateKey(u => new {u.CountryId, u.Name});
            builder
                .HasOne(x => x.Country)
                .WithMany(c => c.Cities)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public static async Task SeedDefaultValues(ApplicationDbContext dbContext)
        {
            if (!await dbContext.Cities.AnyAsync())
            {
                var cities = new List<City>
                {
                    new City {Name = "Yerevan", CountryId = 1, Id = 1},
                    new City {Name = "Ashtarak", CountryId = 1, Id = 2},
                    new City {Name = "Ararat", CountryId = 1, Id = 3},
                    new City {Name = "Armavir", CountryId = 1, Id = 4},
                    new City {Name = "Gavar", CountryId = 1, Id = 5},
                    new City {Name = "Razdan", CountryId = 1, Id = 6},

                    new City {Name = "Moscow", CountryId = 2, Id = 7},
                    new City {Name = "Rostov-on-Don", CountryId = 2, Id = 8},
                    new City {Name = "Saint Petersburg", CountryId = 2, Id = 9},

                    new City {Name = "NewYork", CountryId = 3, Id = 10},
                    new City {Name = "Los-Angeles", CountryId = 3, Id = 11},
                    new City {Name = "Chicago", CountryId = 3, Id = 12}
                };

                await dbContext.AddRangeAsync(cities);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}