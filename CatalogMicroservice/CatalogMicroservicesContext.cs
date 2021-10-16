using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CatalogMicroservice
{
    public partial class CatalogMicroservicesContext : DbContext
    {
        public CatalogMicroservicesContext()
        {
        }

        public CatalogMicroservicesContext(DbContextOptions<CatalogMicroservicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreCategory> StoreCategories { get; set; }
        public virtual DbSet<ItemStores> ItemStores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=N154;Database=catalogmicroservices;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Feedback>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Feedback");

                entity.Property(e => e.Rating)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Text)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Item");

                entity.Property(e => e.Count).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DateAdded)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.PhotoUrl).HasColumnType("ntext");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("ItemCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Producer");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PhotoUrl).HasColumnType("text");

                entity.Property(e => e.YearFounded)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Store>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Store");

                entity.Property(e => e.Address)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.StoreCategoryId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<StoreCategory>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("StoreCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ItemStores>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ItemStores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
