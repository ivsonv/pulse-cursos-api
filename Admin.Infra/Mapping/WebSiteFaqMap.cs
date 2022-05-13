using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infra.Mapping
{
    public class WebSiteFaqMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteFaq> builder)
        {
            builder.ToTable("website_faq");

            builder.HasKey(prop => prop.id);
            builder.Property(prop => prop.title).HasColumnType("varchar(255)");
            builder.Property(prop => prop.sub_title).HasColumnType("varchar(255)");

            builder.HasMany(h => h.Questions)
                   .WithOne(w => w.Faq)
                   .HasForeignKey(f => f.faq_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class WebSiteFaqQuestionMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteFaqQuestion> builder)
        {
            builder.ToTable("website_faq_questions");
            builder.Property(prop => prop.question).HasColumnType("varchar(255)");
            builder.HasKey(prop => prop.id);
        }
    }
}
