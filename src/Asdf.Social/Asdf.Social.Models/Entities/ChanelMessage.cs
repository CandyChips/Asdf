using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class ChanelMessage
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ChanelId")]
        public Chanel Chanel { get; set; }
        [ForeignKey("TextOfMessageId")]
        public TextOfMessage TextOfMessage { get; set; }
        [Required]
        [Column(TypeName="datetime")]
        public DateTime Time {get;set;}
        [Required]
        public bool IsDelete { get; set; }
    }
}