using Domain.Aggregates.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    internal class ConsumptionObjectEntityConfiguration : IEntityTypeConfiguration<ConsumptionObject>
    {
        public void Configure(EntityTypeBuilder<ConsumptionObject> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.ElectricityMeasurementPoints)
                .WithOne(p => p.ConsumptionObject)
                .IsRequired();

            builder.HasMany(p => p.ElectricitySupplyPoints)
                .WithOne(p => p.ConsumptionObject)
                .IsRequired();
        }
    }
}
