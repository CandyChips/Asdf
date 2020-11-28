using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Asdf.Users.Models.Entities
{
    public class Role : IdentityRole<Guid>
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        [Required]
        public bool Deleted { get; set; }
    }
}