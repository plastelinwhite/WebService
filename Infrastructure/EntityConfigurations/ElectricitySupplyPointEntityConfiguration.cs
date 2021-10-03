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
    internal class ElectricitySupplyPointEntityConfiguration : IEntityTypeConfiguration<ElectricitySupplyPoint>
    {
        public void Configure(EntityTypeBuilder<ElectricitySupplyPoint> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.CalculationAccountingDevices)
                .WithOne(p => p.ElectricitySupplyPoint)
                .IsRequired();
        }
    }
}
