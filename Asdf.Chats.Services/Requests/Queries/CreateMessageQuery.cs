using System;
using Asdf.Chats.Models.Entities;
using MediatR;

namespace Asdf.Chats.Services.Requests.Queries
{
    public class CreateMessageQuery : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Text { get; set; }
    }
}