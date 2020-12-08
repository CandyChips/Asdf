using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class GroupPost
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid SenderId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        [ForeignKey("TextOfMessageId")]
        public TextOfMessage TextOfMessage { get; set; }
        [Required]
        [Column(TypeName="datetime")]
        public DateTime Time {get;set;}
        [Required]
        public bool IsDelete { get; set; }
    }
}