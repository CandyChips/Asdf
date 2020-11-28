using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Models.Entities
{
    public class Friendship
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
        [Required]
        [ForeignKey("FriendId")]
        public User Friend { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}