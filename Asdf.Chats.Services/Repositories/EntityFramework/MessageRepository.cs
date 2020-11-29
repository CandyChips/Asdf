using System;
using System.Linq;
using System.Threading.Tasks;
using Asdf.Chats.Models.Entities;
using Asdf.Chats.Services.Contexts;
using Asdf.Chats.Services.Repositories.Interfaces;

namespace Asdf.Chats.Services.Repositories.EntityFramework
{
    public class MessageRepository : BaseEntityFrameworkRepository, IMessageRepository
    {
        public MessageRepository(IDataAccelerator dataAccelerator) : base(dataAccelerator)
        {
        }

        public IQueryable<Message> GetAllMessages()
        {
            return Context.Messages;
        }

        public IQueryable<Message> GetAllMessagesByUserId(Guid id)
        {
            return Context.Messages.Where(x => x.FromUserId == id);
        }

        public async Task<Message> GetMessageByIdAsync(Guid id)
        {
            return await Context.Messages.FindAsync(id);
        }

        public async Task CreateMessageAsync(Message message)
        {
            await Context.Messages.AddAsync(message);
        }

        public void UpdateMessage(Message message)
        {
            Context.Messages.Update(message);
        }

        public void DeleteMessage(Message message)
        {
            Context.Messages.Remove(message);
        }
    }

}
