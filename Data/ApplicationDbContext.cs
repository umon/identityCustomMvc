using identityCustomMvc.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace identityCustomMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<YemekTarifi> YemekTarifleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YemekTarifi>().ToTable("YemekTarifleri", "dbo");
        }
    }
}