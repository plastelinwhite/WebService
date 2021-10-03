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
    internal class CalculationAccountingDeviceEntityConfiguration : IEntityTypeConfiguration<CalculationAccountingDevice>
    {
        public void Configure(EntityTypeBuilder<CalculationAccountingDevice> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.MeasurementMappings)
                .WithOne(p => p.CalculationAccountingDevice)
                .IsRequired();
        }
    }
}
