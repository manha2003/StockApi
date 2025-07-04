using DomainLayer.Entities;
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
            builder.HasIndex(s => s.Symbol).IsUnique();
            builder.Property(s => s.Symbol).IsRequired().HasMaxLength(10);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(250);
            builder.Property(s => s.Exchange).HasMaxLength(50);
            builder.Property(s => s.Sector).HasMaxLength(100);
            builder.Property(s => s.Industry).HasMaxLength(150);
            builder.Property(s => s.Currency).HasMaxLength(10);

            builder.HasMany(s => s.PortfolioItems)
                   .WithOne(pi => pi.Stock)
                   .HasForeignKey(pi => pi.StockId);

            builder.HasMany(s => s.WatchlistItems)
                   .WithOne(wli => wli.Stock)
                   .HasForeignKey(wli => wli.StockId);
        }

    }
    
}
