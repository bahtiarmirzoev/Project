using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Project.Data
{
    public class TrendyolDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder builder = new();

            builder.AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Name).IsRequired().HasMaxLength(25);
                entity.Property(a => a.Password).IsRequired();

                entity.HasIndex(a => a.Name).IsUnique();

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).ValueGeneratedOnAdd();
                entity.Property(a => a.Username).IsRequired().HasMaxLength(25);
                entity.Property(a => a.FirstName).IsRequired().HasMaxLength(25);
                entity.Property(a => a.LastName).IsRequired().HasMaxLength(25);
                entity.Property(a => a.FIN).IsRequired().HasMaxLength(7);
                entity.Property(a => a.Password).IsRequired();

                entity.HasIndex(a => a.Username).IsUnique();
                entity.HasIndex(a => a.FIN).IsUnique();

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).ValueGeneratedOnAdd();
                entity.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18, 2)");

                entity.HasOne(p => p.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(os => os.Id);
                entity.Property(os => os.Id).ValueGeneratedOnAdd();
                entity.Property(os => os.DeliveryState).IsRequired().HasConversion<string>();
                entity.Property(os => os.Time).IsRequired().HasColumnType("datetime2");

                entity.HasOne(os => os.Order)
                .WithMany(o => o.OrderStatus)
                .HasForeignKey(os => os.OrderId)
                .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(25);

                entity.HasIndex(c => c.Name).IsUnique();

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(25);
                entity.Property(p => p.Make).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Description).HasMaxLength(250);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18, 2)");
                                    
                entity.HasIndex(p => p.Name).IsUnique();
                entity.HasIndex(p => p.Make).IsUnique();


                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

            });



            base.OnModelCreating(modelBuilder);
        }
    }
        
}
