using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class ChanelMessageRate
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ChanelMessageId")]
        public ChanelMessage ChanelMessage { get; set; }
        [Required]
        public Guid RaiterId { get; set; }
        [Required]
        public int Stars { get; set; }
    }
}