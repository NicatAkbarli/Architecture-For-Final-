using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Architecture.DataAccess.Concrete.EntityFramework;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=K318Finals;Trusted_Connection=True;MultipleActiveResultSets=true; TrustServerCertificate=True");
    }

    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Affiliate> Affiliates { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentPhoto> CommentPhotos { get; set; }
    public DbSet<Specification> Specifications { get; set; }

    public DbSet<Follower> Followers { get; set; }
     public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WishList> wishLists { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Follower>()
         .HasOne(f => f.User)
         .WithMany(u => u.Followers)
         .HasForeignKey(f => f.UserId)
         .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Follower>()
            .HasOne(f => f.Shop)
            .WithMany()
            .HasForeignKey(f => f.ShopId)
            .OnDelete(DeleteBehavior.Restrict);
            
        

        modelBuilder.Entity<Advertisement>()
         .HasOne(f => f.Shop)
         .WithMany(u => u.Advertisements)
         .HasForeignKey(f => f.ShopId)
         .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Advertisement>()
          .HasOne(f => f.Product)
          .WithMany(u => u.Advertisements)
          .HasForeignKey(f => f.ProductId)
          .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
        .HasOne(f => f.Product)
        .WithMany(u => u.Comments)
        .HasForeignKey(f => f.ProductId)
        .OnDelete(DeleteBehavior.Restrict);
        

        modelBuilder.Entity<Comment>()
                  .HasOne(f => f.User)
                  .WithMany(u => u.Comments)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
