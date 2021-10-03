using Domain.Aggregates.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    internal class CalculationAccountingToMeasurementMappingEntityConfiguration : IEntityTypeConfiguration<CalculationAccountingToMeasurementMapping>
    {
        public void Configure(EntityTypeBuilder<CalculationAccountingToMeasurementMapping> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
