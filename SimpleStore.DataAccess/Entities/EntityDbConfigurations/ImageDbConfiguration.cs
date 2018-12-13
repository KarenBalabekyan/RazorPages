using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleStore.DataAccess.Entities.EntityDbConfigurations
{
    public class ImageDbConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(x => x.Product).WithMany(c => c.Images).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(u => new {u.SortOrder, u.ProductId});
            builder.HasAlternateKey(u => new {u.SortOrder, u.ProductId});
        }
    }
}