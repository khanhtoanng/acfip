using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACFIP.Data.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Camera> Camera { get; set; }
        public virtual DbSet<CameraConfiguration> CameraConfiguration { get; set; }
        public virtual DbSet<CameraSetting> CameraSetting { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ViolationCase> ViolationCase { get; set; }
        public virtual DbSet<ViolationCaseType> ViolationCaseType { get; set; }
        public virtual DbSet<ViolationType> ViolationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //  optionsBuilder.UseSqlServer("Server=SE130120;Database=ACFIPDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__account__roleId__1273C1CD");
            });

            modelBuilder.Entity<Camera>(entity =>
            {
                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Cameras)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK__camera__areaId__1920BF5C");
            });

            modelBuilder.Entity<CameraConfiguration>(entity =>
            {
                // fix bug Update camera by delete { e.CameraId, e.CameraSettingId })
                entity.HasKey(e => new { e.CameraId })
                    .HasName("PK__camera_c__96F24AA52E549714");

                entity.HasOne(d => d.Camera)
                    .WithMany(p => p.CameraConfigurations)
                    .HasForeignKey(d => d.CameraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__camera_co__camer__1BFD2C07");

                entity.HasOne(d => d.CameraSetting)
                    .WithMany(p => p.CameraConfigurations)
                    .HasForeignKey(d => d.CameraSettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__camera_co__camer__1CF15040");
            });

            modelBuilder.Entity<ViolationCase>(entity =>
            {
                entity.HasOne(d => d.Camera)
                    .WithMany(p => p.ViolationCases)
                    .HasForeignKey(d => d.CameraId)
                    .HasConstraintName("FK__violation__camer__21B6055D");
            });

            modelBuilder.Entity<ViolationCaseType>(entity =>
            {
                entity.HasKey(e => new { e.ViolationTypeId, e.ViolationCaseId })
                    .HasName("PK__violatio__1F6F4BB35E4061AC");

                entity.HasOne(d => d.ViolationCase)
                    .WithMany(p => p.ViolationCaseTypes)
                    .HasForeignKey(d => d.ViolationCaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__violation__viola__25869641");

                entity.HasOne(d => d.ViolationType)
                    .WithMany(p => p.ViolationCaseTypes)
                    .HasForeignKey(d => d.ViolationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__violation__viola__24927208");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
