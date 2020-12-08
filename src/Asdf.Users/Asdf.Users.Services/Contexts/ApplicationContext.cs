using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Asdf.Users.Models.Entities;

namespace Asdf.Users.Services.Contexts
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            Update();
        }

        public void Update()
        {
            Users.Load();
            Roles.Load();
            Friendships.Load();
        }
    }

    public class DataInitializer
    {
        public static async Task InitializeRolesAsync(RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role() { Name = "Администратор" });
            await roleManager.CreateAsync(new Role() { Name = "Пользователь" });
        }
    }
}