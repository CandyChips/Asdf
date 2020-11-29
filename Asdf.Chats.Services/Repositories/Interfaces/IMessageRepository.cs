using System;
using System.Linq;
using System.Threading.Tasks;
using Asdf.Chats.Models.Entities;

namespace Asdf.Chats.Services.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAllMessages();        
        IQueryable<Message> GetAllMessagesByUserId(Guid id);
        Task<Message> GetMessageByIdAsync(Guid id);
        Task CreateMessageAsync(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}