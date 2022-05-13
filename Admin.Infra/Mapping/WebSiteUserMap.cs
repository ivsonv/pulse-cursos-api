using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infra.Mapping
{
    public class WebSiteUserMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteUser> builder)
        {
            builder.ToTable("website_users");

            builder.HasKey(prop => prop.id);
            builder.Property(prop => prop.name).HasColumnType("varchar(120)");

            builder.HasMany(h => h.GroupPermissions)
                   .WithOne(w => w.User)
                   .HasForeignKey(f => f.user_id)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class UserGroupPermissionMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.WebSiteUserGroupPermission> builder)
        {
            builder.ToTable("website_users_group_permissions");
            builder.HasKey(prop => prop.id);
        }
    }
}
