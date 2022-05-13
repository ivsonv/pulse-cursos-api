using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infra.Mapping
{
    public class WebSiteCategoryMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteCategory> builder)
        {
            builder.ToTable("website_categories");

            builder.HasKey(prop => prop.id);
            builder.Property(prop => prop.name).HasColumnType("varchar(120)");
            builder.Property(prop => prop.image).HasColumnType("varchar(50)");

            builder.HasMany(h => h.SubCategories)
                   .WithOne(w => w.Parent)
                   .HasForeignKey(f => f.parent_id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
