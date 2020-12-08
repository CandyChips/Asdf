using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class TextOfMessage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(MAX)")]
        public string Text { get; set; }
    }
}