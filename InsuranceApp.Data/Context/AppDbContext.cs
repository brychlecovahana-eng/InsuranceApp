using InsuranceApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<InsuredPersonDbModel> InsuredPersons { get; set; }
        public DbSet<InsuranceDbModel> Insurances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InsuredPersonDbModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<InsuranceDbModel>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<InsuredPersonDbModel>()
                .HasMany(x => x.Insurances)
                .WithOne(x => x.InsuredPerson)
                .HasForeignKey(x => x.InsuredPersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
