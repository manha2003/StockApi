using DomainLayer.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Symbol)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Exchange)
                   .HasMaxLength(50);

            builder.Property(s => s.Sector)
                   .HasMaxLength(100);

            builder.Property(s => s.Industry)
                   .HasMaxLength(100);

            builder.Property(s => s.Currency)
                   .HasMaxLength(10);

            builder.Property(s => s.IsActive)
                   .IsRequired();

            builder.Property(s => s.LastestPrice)
                     .HasPrecision(18, 2);
                     

            builder.Property(s => s.LastPriceUpdatedAt)
                   .IsRequired();

            
            builder.HasMany(s => s.PortfolioItems)
                   .WithOne(pi => pi.Stock)
                   .HasForeignKey(pi => pi.StockId)
                   .OnDelete(DeleteBehavior.Restrict);

          /*  builder.HasMany(s => s.Orders)
                   .WithOne(o => o.Stock)
                   .HasForeignKey(o => o.StockId)
                   .OnDelete(DeleteBehavior.Restrict);*/

            builder.HasMany(s => s.PriceHistory)
                   .WithOne(ph => ph.Stock)
                   .HasForeignKey(ph => ph.StockId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.WatchlistItems)
                   .WithOne(wi => wi.Stock)
                   .HasForeignKey(wi => wi.StockId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
    
}
