using ACFIP_Server.Helpers;
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
        public DbSet<ViolationCase> ViolationCases { get; set; }
        public DbSet<ViolationType> ViolationTypes { get; set; }
        public DbSet<ViolationCaseType> ViolationCaseTypes { get; set; }
        public DbSet<GroupCamera> GroupCameras { get; set; }
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
            var salt = PasswordHelper.generateSalt();
            var admin_password = PasswordHelper.hashSHA512("12345678", salt);
            builder.Entity<Account>().HasData(
                    
                    new Account() { Id = 1, RoleId = 1, DeletedFlag = false, IsActive = true, Salt = salt, HashedPassword = admin_password}
                );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is BaseModel);
            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).CreatedTime = DateTime.UtcNow; 
            }
            return base.SaveChangesAsync();
        }
    }
}
