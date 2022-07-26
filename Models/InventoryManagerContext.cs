using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class InventoryManagerContext : DbContext
    {
        public InventoryManagerContext()
        {
        }

        public InventoryManagerContext(DbContextOptions<InventoryManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=L2202037; Database=InventoryManager; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("employee");

                entity.HasIndex(e => e.Name, "IX_employee")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(75)
                    .HasColumnName("email");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.ItemExpiryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Item_expiry_date");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .HasColumnName("Item_name");

                entity.Property(e => e.ItemOwnerEmail)
                    .HasMaxLength(75)
                    .HasColumnName("Item_ownerEmail");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("money")
                    .HasColumnName("Item_price");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(50)
                    .HasColumnName("Item_type");

                entity.Property(e => e.ItemWeight).HasColumnName("Item_weight");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
