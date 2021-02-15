using ACFIP_Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ACFIP_Server.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<CameraConfiguration> CameraConfigurations { get; set; }
        public DbSet<CameraCamConfig> CameraCamConfigs { get; set; }
        public DbSet<ViolationCase> ViolationCases { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<ViolationCaseType> ViolationCaseTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>().HasData(
                    new Role() { Id = 1, Name = "Admin" },
                    new Role() { Id = 2, Name = "Manager" },
                    new Role() { Id = 3, Name = "Monitor" }
                );
            builder.Entity<ViolationType>().HasData(
                    new ViolationType() { Id = 1, Name = "Vest" },
                    new ViolationType() { Id = 2, Name = "Helmet" }
                );
            builder.Entity<ViolationCaseType>().HasKey(
                    t => new { t.CaseId, t.TypeId }
                );
            builder.Entity<CameraCamConfig>().HasKey(
                    t => new { t.CameraId, t.ConfigId }
                );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // update time when create or update
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).LastModifiedTime = DateTime.UtcNow;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedTime = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
