using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asdf.AdminMenu.Pages.User
{
    public class CreateUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<string> Roles = new List<string>();
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password {get;set;}
        [Required]
        public string Phone { get; set; }
    }
}