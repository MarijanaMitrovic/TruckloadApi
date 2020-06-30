using System;
using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class TruckloadContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Load>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Truck>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Model>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<BillOfLading>().HasQueryFilter(x => !x.IsDeleted);

            modelBuilder.ApplyConfiguration(new DriverConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
            modelBuilder.ApplyConfiguration(new TruckConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());


        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V71QM02\SQLEXPRESS;Initial Catalog=asp-api;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BillOfLading> BillOfLadings { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverLoad> DriverLoads { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
