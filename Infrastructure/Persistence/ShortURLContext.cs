using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;
#nullable disable

namespace Infrastructure.Persistence
{
    public partial class ShortURLContext : DbContext
    {
        public ShortURLContext()
        {
        }

        public ShortURLContext(DbContextOptions<ShortURLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ShortLink> ShortLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ShortURL;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ShortLink>(entity =>
            {
                entity.ToTable("ShortLink");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShortUrl)
                    .IsRequired()
                    .HasColumnName("ShortURL");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
