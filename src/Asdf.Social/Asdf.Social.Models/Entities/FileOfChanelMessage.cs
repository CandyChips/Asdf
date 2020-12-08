using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class FileOfChanelMessage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid FileId { get; set; }
        [Required]
        [ForeignKey("ChanelMessageId")]
        public ChanelMessage ChanelMessage { get; set; }
    }
}