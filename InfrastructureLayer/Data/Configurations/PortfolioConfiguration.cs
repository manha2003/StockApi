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
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.HasOne(u => u.User)
                   .WithMany(u => u.Portfolios) 
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Items)
                   .WithOne(pi => pi.Portfolio)
                   .HasForeignKey(pi => pi.PortfolioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
