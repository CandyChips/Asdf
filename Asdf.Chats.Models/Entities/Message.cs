using System;

namespace Asdf.Chats.Models.Entities
{
    public class Message 
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}