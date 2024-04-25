using Microsoft.EntityFrameworkCore;

namespace Form.Infrastructure.Persistence
{
    public class FormDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TazeBtCase;Integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Shared.Forms> Forms { get; set; }
        public DbSet<Shared.FormFields> FormFields { get; set; }
        public DbSet<Shared.FormFieldValues> FormFieldValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
