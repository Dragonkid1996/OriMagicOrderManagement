using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OrigamiOrdering
{
    public partial class origamiContext : DbContext
    {
        public origamiContext()
        {
        }

        public origamiContext(DbContextOptions<origamiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<JtModelColour> JtModelColours { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=origami;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colour>(entity =>
            {
                entity.Property(e => e.ColourId).HasColumnName("ColourID");

                entity.Property(e => e.Colour1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Colour");
            });

            modelBuilder.Entity<JtModelColour>(entity =>
            {
                entity.HasKey(e => e.IndexId)
                    .HasName("PK__JT_Model__40BC8AA1B78DA58A");

                entity.ToTable("JT_Model_Colours");

                entity.Property(e => e.IndexId).HasColumnName("IndexID");

                entity.Property(e => e.ColourId).HasColumnName("ColourID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.PiecesOfColour).HasColumnName("Pieces_Of_Colour");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.JtModelColours)
                    .HasForeignKey(d => d.ColourId)
                    .HasConstraintName("FK__JT_Model___Colou__3D5E1FD2");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.JtModelColours)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__JT_Model___Model__3C69FB99");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.LinkToPhoto)
                    .IsUnicode(false)
                    .HasColumnName("Link_To_Photo")
                    .HasDefaultValueSql("('http://www.facebook.com/OriMagicShop')");

                entity.Property(e => e.LinkToTutorial)
                    .IsUnicode(false)
                    .HasColumnName("Link_To_Tutorial")
                    .HasDefaultValueSql("('http://www.youtube.com')");

                entity.Property(e => e.ModelComplexity)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Model_Complexity")
                    .HasDefaultValueSql("('M')")
                    .IsFixedLength(true);

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Model_Name");

                entity.Property(e => e.ModelPiecesNumber).HasColumnName("Model_Pieces_Number");

                entity.Property(e => e.ModelPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Model_Price");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Total_Price");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__Orders__ModelID__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
