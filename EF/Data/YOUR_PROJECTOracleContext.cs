using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using YOUR_PROJECT.EF.Models;

#nullable disable

namespace YOUR_PROJECT.EF
{
    public partial class YOUR_PROJECTOracleContext : DbContext
    {
        public YOUR_PROJECTOracleContext()
        {
        }

        public YOUR_PROJECTOracleContext(DbContextOptions<YOUR_PROJECTOracleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; }
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##_UD_CDREICH")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.Id).HasPrecision(10);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.AccessFailedCount).HasPrecision(10);

                entity.Property(e => e.EmailConfirmed).HasPrecision(1);

                entity.Property(e => e.LockoutEnabled).HasPrecision(1);

                entity.Property(e => e.LockoutEnd).HasPrecision(7);

                entity.Property(e => e.PhoneNumberConfirmed).HasPrecision(1);

                entity.Property(e => e.TwoFactorEnabled).HasPrecision(1);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.Id).HasPrecision(10);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<DeviceCode>(entity =>
            {
                entity.Property(e => e.CreationTime).HasPrecision(7);

                entity.Property(e => e.Expiration).HasPrecision(7);
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.Property(e => e.ConsumedTime).HasPrecision(7);

                entity.Property(e => e.CreationTime).HasPrecision(7);

                entity.Property(e => e.Expiration).HasPrecision(7);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
