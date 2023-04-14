using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class ShopperContext : DbContext
    {
        public ShopperContext()
        {
        }

        public ShopperContext(DbContextOptions<ShopperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Filter> Filters { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<PriceChange> PriceChanges { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<PurchaseItem> PurchaseItems { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public virtual DbSet<StatusOfPurchase> StatusOfPurchases { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(150)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerFirstName)
                    .HasMaxLength(50)
                    .HasColumnName("customer_first_name");

                entity.Property(e => e.CustomerLastName)
                    .HasMaxLength(50)
                    .HasColumnName("customer_last_name");

                entity.Property(e => e.CustomerPassword)
                    .HasMaxLength(50)
                    .HasColumnName("customer_password");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(20)
                    .HasColumnName("customer_phone");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("deliveries");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__deliverie__produ__3864608B");

                entity.HasOne(d => d.Stock)
                    .WithMany()
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__deliverie__stock__395884C4");
            });

            modelBuilder.Entity<Filter>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.FilterId })
                    .HasName("PK_FILTERS");

                entity.ToTable("filters");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.FilterId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("filter_id");

                entity.Property(e => e.FilterName)
                    .HasMaxLength(100)
                    .HasColumnName("filter_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Filters)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__filters__categor__4D5F7D71");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturers");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.ManufacturerName)
                    .HasMaxLength(150)
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<PriceChange>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.DatePriceChange })
                    .HasName("PK_PRICE_CHANGE");

                entity.ToTable("price_change");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.DatePriceChange)
                    .HasColumnType("date")
                    .HasColumnName("date_price_change")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.NewPrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("new_price");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PriceChanges)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__price_cha__produ__367C1819");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("product_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("product_price")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__products__catego__31B762FC");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__products__manufa__32AB8735");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__products__stock___30C33EC3");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchases");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("purchase_date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchases__custo__3F115E1A");
            });

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseId, e.ProductId })
                    .HasName("PK_PURCHASE_ITEMS");

                entity.ToTable("purchase_items");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("product_price");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___produ__41EDCAC5");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseItems)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__purchase___purch__42E1EEFE");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("shopping_cart");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("product_count")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("product_price")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shopping___custo__46B27FE2");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shopping___produ__47A6A41B");
            });

            modelBuilder.Entity<StatusOfPurchase>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("status_of_purchase");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.PurchaseStatus)
                    .HasMaxLength(20)
                    .HasColumnName("purchase_status")
                    .HasDefaultValueSql("('in process')");

                entity.HasOne(d => d.Purchase)
                    .WithMany()
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__status_of__purch__4A8310C6");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.StockId)
                    .HasName("PK__warehous__E8666862EDFB854D");

                entity.ToTable("warehouses");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.Property(e => e.StockAddress)
                    .HasMaxLength(200)
                    .HasColumnName("stock_address");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
