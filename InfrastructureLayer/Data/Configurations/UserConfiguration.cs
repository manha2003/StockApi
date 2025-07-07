using DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User> 
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.Property(u => u.Bio)
                   .HasMaxLength(1000);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.HasMany(u => u.Portfolios)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.Watchlists)
                   .WithOne(w => w.User)
                   .HasForeignKey(w => w.UserId);

            /*builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId);*/

            builder.HasMany(u => u.Posts)
                     .WithOne(p => p.User)
                     .HasForeignKey(p => p.UserId);


        }
    }
}

