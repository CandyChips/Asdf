using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Social.Models.Entities
{
    public class GroupSubscribtion
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        [Required]
        public Guid SubscriberId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}