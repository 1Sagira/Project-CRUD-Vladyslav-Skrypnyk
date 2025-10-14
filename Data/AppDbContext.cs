using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Models;

namespace ZadanieApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Zadanie> Zadania { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Zadanie>(entity =>
            {
                entity.ToTable("zadania");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Tytul).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Opis).HasMaxLength(2000);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Priorytet).HasDefaultValue(3);
            });
        }
    }
}