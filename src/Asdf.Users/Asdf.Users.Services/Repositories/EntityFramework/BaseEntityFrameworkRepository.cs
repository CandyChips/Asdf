using Asdf.Users.Services.Contexts;

namespace Asdf.Users.Services.Repositories.EntityFramework
{
    public abstract class BaseEntityFrameworkRepository
    {
        protected readonly IDataAccelerator DataAccelerator; 
        protected ApplicationContext Context { get { return this.DataAccelerator.Context; } }

        public BaseEntityFrameworkRepository(IDataAccelerator dataAccelerator) { this.DataAccelerator = dataAccelerator; }
    }
}