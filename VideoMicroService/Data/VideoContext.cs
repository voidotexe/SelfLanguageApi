/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace VideoMicroService.Data
{
    public partial class VideoContext : DbContext
    {
        public VideoContext()
        {
        }

        public VideoContext(DbContextOptions<VideoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subtitle> Subtitles { get; set; }
        public virtual DbSet<Transcription> Transcriptions { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Subtitle>(entity =>
            {
                entity.HasIndex(e => e.Content, "UQ__Subtitle__CD856C0069D26FCF")
                    .IsUnique();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Subtitles)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subtitles__Video__619B8048");
            });

            modelBuilder.Entity<Transcription>(entity =>
            {
                entity.HasIndex(e => e.VideoId, "UQ__Transcri__BAE5126B96CB6A89")
                    .IsUnique();

                entity.HasIndex(e => e.Content, "UQ__Transcri__CD856C0046AADCB6")
                    .IsUnique();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Video)
                    .WithOne(p => p.Transcription)
                    .HasForeignKey<Transcription>(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transcrip__Video__66603565");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasIndex(e => e.Title, "UQ__Videos__2CB664DC53F4A21C")
                    .IsUnique();

                entity.HasIndex(e => e.Link, "UQ__Videos__B827DC6957910D25")
                    .IsUnique();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
