using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.Property(x => x.From).IsRequired();
            builder.Property(x => x.To).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasMany(l => l.DriverLoads)
              .WithOne(x => x.Load).HasForeignKey(d => d.LoadId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
