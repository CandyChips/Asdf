using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(MAX)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName="nvarchar(MAX)")]
        public string Description { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
        [Required]
        [Column(TypeName="date")]
        public DateTime CreationDate {get;set;}
        [Required]
        public bool IsDelete { get; set; }
    }
}