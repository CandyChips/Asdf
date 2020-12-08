using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class Chanel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName="date")]
        public DateTime CreationDate {get;set;}
        [Required]
        public bool IsDelete { get; set; }
    }
}