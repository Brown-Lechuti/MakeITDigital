using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MakeITDigital.Models
{
    public partial class MarketMedia : DbContext
    {
        public MarketMedia()
        {
        }

        public MarketMedia(DbContextOptions<MarketMedia> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Metum> Meta { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MarketMedia;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.PhotoId).ValueGeneratedNever();

                entity.Property(e => e.City).IsFixedLength(true);

                entity.Property(e => e.Country).IsFixedLength(true);

                entity.Property(e => e.ProvinceOrState).IsFixedLength(true);

                entity.HasOne(d => d.Photo)
                    .WithOne(p => p.Location)
                    .HasForeignKey<Location>(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Photo");
            });

            modelBuilder.Entity<Metum>(entity =>
            {
                entity.Property(e => e.PhotoId).ValueGeneratedNever();

                entity.Property(e => e.Caption).IsFixedLength(true);

                entity.Property(e => e.ModStamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Photo)
                    .WithOne(p => p.Metum)
                    .HasForeignKey<Metum>(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meta_Photo");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.DateUploaded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title).IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_many_Photos");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TaggedEmail).IsFixedLength(true);

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK_Tag_Photo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsFixedLength(true);

                entity.Property(e => e.FirstName).IsFixedLength(true);

                entity.Property(e => e.LastName).IsFixedLength(true);

                entity.Property(e => e.PasswordHash).IsFixedLength(true);

                entity.Property(e => e.SignUpDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
