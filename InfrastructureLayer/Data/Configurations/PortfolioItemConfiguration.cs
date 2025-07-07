using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainLayer.Entities.Portfolios;

namespace InfrastructureLayer.Data.Configurations
{
    public class PortfolioItemConfiguration : IEntityTypeConfiguration<PortfolioItem>  
    {
        public void Configure(EntityTypeBuilder<PortfolioItem> builder)
        {
            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.Quantity)
                   .HasPrecision(18, 2);

            builder.Property(pi => pi.AvgBuyPrice)
                   .HasPrecision(18, 2);

            builder.HasOne(pi => pi.Portfolio)
                   .WithMany(p => p.Items)
                   .HasForeignKey(pi => pi.PortfolioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pi => pi.Stock)
                   .WithMany(s => s.PortfolioItems)
                   .HasForeignKey(pi => pi.StockId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
