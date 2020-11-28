using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asdf.Users.Models.Entities
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        [ForeignKey("FriendId")]
        public User Friend { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}