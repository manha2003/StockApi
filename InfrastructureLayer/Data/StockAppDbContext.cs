using DomainLayer.Entities.Portfolios;
using DomainLayer.Entities.Social;
using DomainLayer.Entities.Stocks;
using DomainLayer.Entities.Users;
using DomainLayer.Entities.Watchlists;
using Microsoft.EntityFrameworkCore;

public class StockAppDbContext : DbContext
{
    public StockAppDbContext(DbContextOptions<StockAppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<PortfolioItem> PortfolioItems { get; set; }
   // public DbSet<Order> Orders { get; set; }
    public DbSet<StockPriceHistory> StockPriceHistories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Watchlist> Watchlists { get; set; }

    //public DbSet<Comment> Comments { get; set; }
    //public DbSet<PostLike> PostLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockAppDbContext).Assembly);
    }
}
