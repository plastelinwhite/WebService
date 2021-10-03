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
    internal class ElectricityMeasurementPointEntityConfiguration : IEntityTypeConfiguration<ElectricityMeasurementPoint>
    {
        public void Configure(EntityTypeBuilder<ElectricityMeasurementPoint> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.ElectricityTransformer);
            builder.OwnsOne(p => p.ElectricityMeter);
            builder.OwnsOne(p => p.VoltageTransformer);

            builder.HasMany(p => p.CalculationAccountingDevicesMapping)
                .WithOne(p => p.ElectricityMeasurementPoint)
                .IsRequired();
        }
    }
}
