using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infra.Mapping
{
    public class WebSiteCarouselMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteCarousel> builder)
        {
            builder.ToTable("website_carousels");

            builder.HasKey(prop => prop.id);
            builder.Property(prop => prop.name).HasColumnType("varchar(120)");
            builder.Property(prop => prop.image).HasColumnType("varchar(50)");
            builder.Property(prop => prop.image_mobile).HasColumnType("varchar(50)");
            builder.Property(prop => prop.start).HasColumnType("timestamp");
            builder.Property(prop => prop.end).HasColumnType("timestamp");
        }
    }
}
