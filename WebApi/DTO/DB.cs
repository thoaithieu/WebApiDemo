using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class DB : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<VehicleAppraisal> VehicleAppraisals { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Condition>().ToTable("Condition");
            modelBuilder.Entity<Model>().ToTable("Model");
            modelBuilder.Entity<Make>().ToTable("Make");
            modelBuilder.Entity<VehicleAppraisal>().ToTable("VehicleAppraisal");
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<AppUserRole>().ToTable("AppUserRole");
        }
    }
}