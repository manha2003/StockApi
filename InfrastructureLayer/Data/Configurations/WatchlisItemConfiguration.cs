using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities.Watchlists;

namespace InfrastructureLayer.Data.Configurations
{
    public class WatchlisItemConfiguration : IEntityTypeConfiguration<WatchlistItem>
    {
        public void Configure(EntityTypeBuilder<WatchlistItem> builder)
        {
            builder.HasKey(wli => wli.Id);

            builder.Property(wli => wli.StockId)
                   .IsRequired();

            builder.Property(wli => wli.WatchlistId)
                   .IsRequired();

            builder.HasOne(wli => wli.Watchlist)
                   .WithMany(w => w.Items)
                   .HasForeignKey(wli => wli.WatchlistId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wli => wli.Stock)
                   .WithMany(s => s.WatchlistItems)
                   .HasForeignKey(wli => wli.StockId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
