using Microsoft.EntityFrameworkCore;
using StudentClass.Data.Models;

namespace StudentClass.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserInvite> UserInvites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoles>().HasKey(key => new { key.UserId, key.RoleId });
            builder.Entity<Role>().HasAlternateKey(key => key.Name);
            builder.Entity<User>().HasAlternateKey(key => key.Email);
        }
    }
}
