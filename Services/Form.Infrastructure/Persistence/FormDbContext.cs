using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Form.Infrastructure.Persistence
{
    public class FormDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TazeBtCase;Integrated Security=true;TrustServerCertificate=true;");
        }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<FormFields> FormFields { get; set; }
        public DbSet<FormFieldValues> FormFieldValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
