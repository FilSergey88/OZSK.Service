using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OZSK.Service.Model;

namespace OZSK.Service.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Cipherlist> Cipherlists { get; set; }
        public virtual DbSet<Consignee> Consignees { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ShippingName> ShippingNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>().ToTable("Auto", "dbo");
            modelBuilder.Entity<Auto>()
                .HasMany(q => q.Drivers)
                .WithOne(q => q.Auto)
                .HasForeignKey(q => q.AutoId);
            modelBuilder.Entity<Auto>().Property(q => q.Ts).IsRowVersion();

            modelBuilder.Entity<Carrier>().ToTable("Carrier", "dbo");
            modelBuilder.Entity<Carrier>()
                .HasMany(q => q.Autos)
                .WithOne(q => q.Carrier)
                .HasForeignKey(q => q.CarrierId);
            
            modelBuilder.Entity<Carrier>().Property(q => q.Ts).IsRowVersion();


            modelBuilder.Entity<Cipherlist>().ToTable("Cipherlist", "dbo");
            modelBuilder.Entity<Cipherlist>().Property(q => q.Ts).IsRowVersion();
            modelBuilder.Entity<Cipherlist>();

            modelBuilder.Entity<Driver>().ToTable("Driver", "dbo");
            modelBuilder.Entity<Driver>().Property(q => q.Ts).IsRowVersion();
            modelBuilder.Entity<Driver>()
                .HasOne(q => q.Auto)
                .WithMany(q => q.Drivers)
                .HasForeignKey(q => q.AutoId);
            modelBuilder.Entity<ShippingName>().ToTable("ShippingName", "dbo");
            modelBuilder.Entity<ShippingName>().Property(q => q.Ts).IsRowVersion();
            modelBuilder.Entity<Consignee>().ToTable("Consignee", "dbo");
            modelBuilder.Entity<Consignee>().Property(q => q.Ts).IsRowVersion();
            modelBuilder.Entity<Consignee>()
                .HasMany(q => q.Cipherlists)
                .WithOne(q => q.Consignee)
                .HasForeignKey(q => q.ConsigneeId);

        }
    }
}