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
    public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist> 
    {
        public void Configure (EntityTypeBuilder<Watchlist> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(w => w.CreatedAt)
                   .IsRequired();

            builder.HasOne(u => u.User)
                   .WithMany(u => u.Watchlists)
                   .HasForeignKey(w => w.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.Items)
                   .WithOne(wli => wli.Watchlist)
                   .HasForeignKey(wli => wli.WatchlistId)
                   .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
