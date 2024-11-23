using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories.Entities;

public partial class KoiFarmShopDbContext : DbContext
{
    public KoiFarmShopDbContext()
    {
    }

    public KoiFarmShopDbContext(DbContextOptions<KoiFarmShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<KhoHang> KhoHangs { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=desktop-gh4saa0\\SQLEXPRESS03;Database=KoiFarmShop;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B35666AEB");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(100)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Customer__B7C92638351D2570");

            entity.ToTable("Customer");

            entity.Property(e => e.IdUser).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Employee__B7C926385926BF07");

            entity.ToTable("Employee");

            entity.Property(e => e.IdUser).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Functions).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(15);
        });

        modelBuilder.Entity<KhoHang>(entity =>
        {
            entity.HasKey(e => new { e.CategoryId, e.ProductId }).HasName("PK__KhoHang__D249F6454A7F4CCB");

            entity.ToTable("KhoHang");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(100)
                .HasColumnName("CategoryID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.KhoHangs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhoHang__Categor__46E78A0C");

            entity.HasOne(d => d.Product).WithMany(p => p.KhoHangs)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhoHang__Product__47DBAE45");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF89C67E6C");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("OrderID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IdUser).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Orders__IdUser__403A8C7D");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__OrderDet__08D097C12EAA6389");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderId)
                .HasMaxLength(100)
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([Quantity]*[Price])", false)
                .HasColumnType("decimal(29, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__4316F928");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__440B1D61");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED5FD20427");

            entity.Property(e => e.ProductId)
                .HasMaxLength(100)
                .HasColumnName("ProductID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.CategoryId)
                .HasMaxLength(100)
                .HasColumnName("CategoryID");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
