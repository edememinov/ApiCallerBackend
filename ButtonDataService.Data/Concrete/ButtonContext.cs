using ButtonDataService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ButtonDataService.Data.Concrete
{
    public class ButtonContext : DbContext
    {
        public ButtonContext(DbContextOptions<ButtonContext> options)
        : base(options)
        {
        }

        public DbSet<Canvas> Canvases { get; set; }
        public DbSet<Button> Buttons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
