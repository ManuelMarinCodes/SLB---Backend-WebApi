using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SLB.Models
{
    public partial class WideWorldImportersContext : DbContext
    {
        public WideWorldImportersContext()
        {
        }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\LocalSLBDB;Database=WideWorldImporters;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Customers", "Website");

                entity.Property(e => e.AlternateContact).HasMaxLength(50);

                entity.Property(e => e.BuyingGroupName).HasMaxLength(50);

                entity.Property(e => e.CityName).HasMaxLength(50);

                entity.Property(e => e.CustomerCategoryName).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryMethod).HasMaxLength(50);

                entity.Property(e => e.DeliveryRun).HasMaxLength(5);

                entity.Property(e => e.FaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PrimaryContact).HasMaxLength(50);

                entity.Property(e => e.RunPosition).HasMaxLength(5);

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("WebsiteURL");
            });

            modelBuilder.HasSequence<int>("BuyingGroupID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("CityID", "Sequences").StartsAt(38187);

            modelBuilder.HasSequence<int>("ColorID", "Sequences").StartsAt(37);

            modelBuilder.HasSequence<int>("CountryID", "Sequences").StartsAt(242);

            modelBuilder.HasSequence<int>("CustomerCategoryID", "Sequences").StartsAt(9);

            modelBuilder.HasSequence<int>("CustomerID", "Sequences").StartsAt(1062);

            modelBuilder.HasSequence<int>("DeliveryMethodID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("InvoiceID", "Sequences").StartsAt(70511);

            modelBuilder.HasSequence<int>("InvoiceLineID", "Sequences").StartsAt(228266);

            modelBuilder.HasSequence<int>("OrderID", "Sequences").StartsAt(73596);

            modelBuilder.HasSequence<int>("OrderLineID", "Sequences").StartsAt(231413);

            modelBuilder.HasSequence<int>("PackageTypeID", "Sequences").StartsAt(15);

            modelBuilder.HasSequence<int>("PaymentMethodID", "Sequences").StartsAt(5);

            modelBuilder.HasSequence<int>("PersonID", "Sequences").StartsAt(3262);

            modelBuilder.HasSequence<int>("PurchaseOrderID", "Sequences").StartsAt(2075);

            modelBuilder.HasSequence<int>("PurchaseOrderLineID", "Sequences").StartsAt(8368);

            modelBuilder.HasSequence<int>("SpecialDealID", "Sequences").StartsAt(3);

            modelBuilder.HasSequence<int>("StateProvinceID", "Sequences").StartsAt(54);

            modelBuilder.HasSequence<int>("StockGroupID", "Sequences").StartsAt(11);

            modelBuilder.HasSequence<int>("StockItemID", "Sequences").StartsAt(228);

            modelBuilder.HasSequence<int>("StockItemStockGroupID", "Sequences").StartsAt(443);

            modelBuilder.HasSequence<int>("SupplierCategoryID", "Sequences").StartsAt(10);

            modelBuilder.HasSequence<int>("SupplierID", "Sequences").StartsAt(14);

            modelBuilder.HasSequence<int>("SystemParameterID", "Sequences").StartsAt(2);

            modelBuilder.HasSequence<int>("TransactionID", "Sequences").StartsAt(336253);

            modelBuilder.HasSequence<int>("TransactionTypeID", "Sequences").StartsAt(14);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
