#pragma warning disable CS8618 

using Domain.Aggregates.Organization;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Organization> Organizations { get; private set; }

        public DbSet<ChildOrganization> ChildOrganizations { get; private set; }

        public DbSet<ConsumptionObject> ConsumptionObjects { get; private set; }

        public DbSet<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; private set; }

        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints { get; private set; }

        public DbSet<CalculationAccountingDevice> CalculationAccounts { get; private set;}

        public DbSet<CalculationAccountingToMeasurementMapping> CalculationAccountingToMeasurementMappings {  get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
