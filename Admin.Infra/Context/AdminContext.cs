using Admin.Domain.Entities;
using Admin.Infra.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Admin.Infra;

public class AdminContext : DbContext
{
    public AdminContext(DbContextOptions<AdminContext> options) : base(options)
    {
        base.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<WebSiteUser> WebSiteUsers { get; set; }
    public DbSet<WebSiteCategory> WebSiteCategories { get; set; }
    public DbSet<WebSiteCarousel> WebSiteCarousels { get; set; }
    public DbSet<WebSiteFaq> WebSiteFaq { get; set; }
    public DbSet<WebSiteFaqQuestion> WebSiteFaqQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AutoMapperContextWebSite();
        modelBuilder.AutoMapperContextCustomer();
    }
}