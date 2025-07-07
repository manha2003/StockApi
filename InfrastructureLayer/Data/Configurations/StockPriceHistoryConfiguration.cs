using DomainLayer.Entities.Stocks;
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
            builder.HasKey(sph => sph.StockHistoryId);

            builder.Property(h => h.StockId)
                   .IsRequired();

            builder.Property(sph => sph.Timestamp)
                   .IsRequired();

            builder.Property(sph => sph.OpenPrice)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.HighPrice)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.LowPrice)
                   .HasPrecision(18, 2);

            builder.Property(sph => sph.ClosePrice)
                   .HasPrecision(18, 2);

            builder.Property(h => h.Volume)
                   .IsRequired();

            builder.HasOne(sph => sph.Stock)
                   .WithMany(s => s.PriceHistory)
                   .HasForeignKey(sph => sph.StockId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
