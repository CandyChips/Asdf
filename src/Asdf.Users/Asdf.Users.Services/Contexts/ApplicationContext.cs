using Asdf.Users.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Services.Contexts
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Role> Roles {get;set;}
        public DbSet<Friendship> Friendships {get;set;}
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            Update();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public void Update()
        {
            Users.Load();
            Roles.Load();
            Friendships.Load();
        }
    }
}