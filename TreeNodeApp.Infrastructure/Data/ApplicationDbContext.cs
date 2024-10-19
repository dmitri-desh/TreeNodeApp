using Microsoft.EntityFrameworkCore;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Core.Enums;

namespace TreeNodeApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tree> Trees { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionLog>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ExceptionLog>()
                .Property(e => e.Type)
                .HasConversion<string>(); // Конвертация enum в строку
        }
    }
}
