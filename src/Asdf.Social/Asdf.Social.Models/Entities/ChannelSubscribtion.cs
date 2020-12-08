using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class ChannelSubscribtion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid SubscriberId { get; set; }
        [ForeignKey("ChanelId")]
        public Chanel Chanel { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}