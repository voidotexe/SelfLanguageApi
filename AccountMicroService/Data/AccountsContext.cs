/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using Microsoft.EntityFrameworkCore;

namespace AccountMicroService.Data
{
    public partial class AccountsContext : DbContext
    {
        public AccountsContext()
        {
        }

        public AccountsContext(DbContextOptions<AccountsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Account__A9D105340A940CBD")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Account__C9F28456A516AE8B")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
