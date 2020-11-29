using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Asdf.Chats.Services.Contexts
{
    public class EntityFrameworkAccelerator : IDataAccelerator
    {
        private ApplicationContext _context;

        public ApplicationContext Context
        {
            get => _context;
            private set => _context = value;
        }

        public EntityFrameworkAccelerator(ApplicationContext context)
        {
            Context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}