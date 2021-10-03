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
    public class ChildOrganizationEntityConfiguration : IEntityTypeConfiguration<ChildOrganization>
    {
        public void Configure(EntityTypeBuilder<ChildOrganization> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.ConsumptionObjects)
                .WithOne(p => p.Organization)
                .IsRequired();
        }
    }
}
