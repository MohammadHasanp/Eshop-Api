using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CommentAgg;
using Shop.Domain.OrderAgg;
using Shop.Domain.ProductAgg;
using Shop.Domain.RoleAgg;
using Shop.Domain.SellerAgg;
using Shop.Domain.SiteEntities;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef._Context
{
    public class ShopContext : DbContext
    {
        private readonly IMediator _publisher;
        public ShopContext(DbContextOptions<ShopContext> option, IMediator publisher) : base(option)
        {
            _publisher = publisher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShippingMothod> ShippingMothods{ get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modifiedEntities = GetModifiedEntities();
            await PublishEvents(modifiedEntities);
            return await base.SaveChangesAsync(cancellationToken);
        }
        private List<AggregateRoot> GetModifiedEntities() =>
            ChangeTracker.Entries<AggregateRoot>()
                .Where(x => x.State != EntityState.Detached)
                .Select(c => c.Entity)
                .Where(c => c.BaseDomains.Any()).ToList();

        private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.BaseDomains;
                foreach (var domainEvent in events)
                {
                    await _publisher.Publish(domainEvent);
                }
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}