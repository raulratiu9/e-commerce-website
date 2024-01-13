using Consumer.Models;
using Consumer.Models.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Data
{
    public class ShopContext : IdentityDbContext<User, Role, int>
    {
        public ShopContext(DbContextOptions<ShopContext> options)
             : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Basket>().ToTable("Baskets");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Review>().ToTable("Reviews");



            builder
                .Entity<User>()
                .HasOne(a => a.Address)
                .WithOne()
                .HasForeignKey<UserAddress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Role>()
                .HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Member",
                        NormalizedName = "MEMBER"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}
