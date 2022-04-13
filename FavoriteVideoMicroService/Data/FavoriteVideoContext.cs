using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FavoriteVideoMicroService.Data
{
    public partial class FavoriteVideoContext : DbContext
    {
        public FavoriteVideoContext()
        {
        }

        public FavoriteVideoContext(DbContextOptions<FavoriteVideoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavoriteVideo> FavoriteVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FavoriteVideo>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
