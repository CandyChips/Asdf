using Asdf.Chats.Services.Contexts;

namespace Asdf.Chats.Services.Repositories.EntityFramework
{
    public abstract class BaseEntityFrameworkRepository
    {
        protected readonly IDataAccelerator DataAccelerator; 
        protected ApplicationContext Context => DataAccelerator.Context;

        public BaseEntityFrameworkRepository(IDataAccelerator dataAccelerator) { DataAccelerator = dataAccelerator; }
    }
}