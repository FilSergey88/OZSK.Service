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
        public virtual DbSet<Auto> Autos{ get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Cipherlist> Cipherlists { get; set; }
        public virtual DbSet<Consignee> Consignees { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<ShippingName> ShippingNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>().ToTable("Auto", "dbo");
            modelBuilder.Entity<Carrier>().ToTable("Carrier", "dbo");
            modelBuilder.Entity<Cipherlist>().ToTable("Cipherlist", "dbo");
            modelBuilder.Entity<Driver>().ToTable("Driver", "dbo");
            modelBuilder.Entity<ShippingName>().ToTable("ShippingName", "dbo");
            modelBuilder.Entity<Consignee>().ToTable("Consignee", "dbo");
        }
    }
}
