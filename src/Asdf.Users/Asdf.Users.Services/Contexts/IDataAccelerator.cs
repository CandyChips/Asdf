using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Asdf.Users.Services.Contexts
{
    public interface IDataAccelerator
    {
        ApplicationContext Context {get;}
        IDbContextTransaction BeginTransaction();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}