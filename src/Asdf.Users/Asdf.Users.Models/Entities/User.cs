using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Asdf.Users.Models.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName="nvarchar(MAX)")]
        public string Name { get; set; }
        [Required]
        public bool Deleted { get; set; }
    }
}