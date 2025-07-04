using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Configurations
{
    public class StockPriceHistoryConfiguration : IEntityTypeConfiguration<StockPriceHistory>
    {
        public void Configure(EntityTypeBuilder<StockPriceHistory> builder)
        {
            builder.HasKey(sph => sph.Id);

            builder.Property(sph => sph.Timestamp)
                   .IsRequired();

            builder.Property(sph => sph.Open)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.High)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.Low)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.Close)
                   .HasPrecision(18, 2);

            builder.HasOne(sph => sph.Stock)
                   .WithMany()
                   .HasForeignKey(sph => sph.StockId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
