using System;
using Microsoft.EntityFrameworkCore;
using TestWebProjec3T.DAL.Entites;

namespace TestWebProjec3T.DAL.Context
{
    public class EmployeeDbContext: DbContext
    {

        public EmployeeDbContext()
        {

        }
        public virtual DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TestWebProjec3T;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Name).HasMaxLength(100);
               
            });
        }
    }
}
