using Asdf.Chats.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Chats.Services.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages {get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            Update();
        }
        
        
        public void Update()
        {
            Messages.Load();
        }
    }
}