using EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EFCoreConsoleApp.Data
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Database=MyVitomeDB;User ID=sa;Password=dev$123%;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonthlyBilling>()
                .HasIndex(e => new { e.year, e.month, e.partnerToken })
                .IsUnique();
            modelBuilder.Entity<Contract>()
                .HasIndex(e => e.partnerToken)
                .IsUnique();
        }

        public virtual DbSet<BillingTransaction> BillTransactions { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<MonthlyBilling> MonthlyBillings { get; set; }
        public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    }
}
