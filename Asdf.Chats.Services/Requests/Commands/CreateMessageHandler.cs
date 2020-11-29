using System;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Chats.Models.Entities;
using Asdf.Chats.Services.Repositories.Interfaces;
using Asdf.Chats.Services.Requests.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Asdf.Chats.Services.Requests.Commands
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageQuery, bool>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<bool> Handle(CreateMessageQuery request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                FromUserId = request.FromUserId,
                ToUserId = request.ToUserId,
                Text = request.Text
            };
            try
            {
                await _messageRepository.CreateMessageAsync(message);
                return true;
            }
            catch(Exception ex)
            {
                //todo: добавить логгер
                return false;
            }
        }
    }
}