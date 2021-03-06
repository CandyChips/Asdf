using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Asdf.Users.Models.Entities
{
    public class Role : IdentityRole
    {
        [Required]
        public bool Deleted { get; set; }
    }
}