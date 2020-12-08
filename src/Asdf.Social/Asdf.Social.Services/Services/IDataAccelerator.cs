using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Asdf.Social.Services.Contexts
{
    public interface IDataAccelerator
    {
        ApplicationContext Context {get;}
        IDbContextTransaction BeginTransaction();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}