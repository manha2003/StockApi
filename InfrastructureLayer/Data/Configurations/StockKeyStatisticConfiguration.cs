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
    public class StockKeyStatisticConfiguration : IEntityTypeConfiguration<StockKeyStatistic>
    {
        public void Configure(EntityTypeBuilder<StockKeyStatistic> builder)
        {
            builder.HasKey(sks => sks.Id);

            builder.HasOne(sks => sks.Stock)
               .WithOne(stock => stock.KeyStatistic)
               .HasForeignKey<StockKeyStatistic>(sks => sks.StockId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sks => sks.PERatio).HasPrecision(18, 4);
            builder.Property(sks => sks.PEG).HasPrecision(18, 4);
            builder.Property(sks => sks.ROE).HasPrecision(18, 4);
            builder.Property(sks => sks.ROA).HasPrecision(18, 4);
            builder.Property(sks => sks.ProfitMargin).HasPrecision(18, 4);
            builder.Property(sks => sks.OperatingMargin).HasPrecision(18, 4);
            builder.Property(sks => sks.DebtToEquity).HasPrecision(18, 4);
            builder.Property(sks => sks.CurrentRatio).HasPrecision(18, 4);

            builder.Property(sks => sks.EarningsPerShare).HasPrecision(18, 4);
            builder.Property(sks => sks.Revenue).HasPrecision(18, 4);
            builder.Property(sks => sks.GrossProfit).HasPrecision(18, 4);
            builder.Property(sks => sks.EBITDA).HasPrecision(18, 4);

            builder.Property(sks => sks.DividendYield).HasPrecision(18, 4);
            builder.Property(sks => sks.DividendPerShare).HasPrecision(18, 4);

            builder.Property(sks => sks.MarketCap).HasPrecision(18, 4);
            builder.Property(sks => sks.BookValue).HasPrecision(18, 4);
            builder.Property(sks => sks.PriceToBook).HasPrecision(18, 4);

            builder.Property(sks => sks.DividendDate).HasColumnType("datetime");
            builder.Property(sks => sks.LastUpdated).IsRequired();
        }
    }
}
