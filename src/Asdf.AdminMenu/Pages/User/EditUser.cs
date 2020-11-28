using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asdf.AdminMenu.Pages.User
{
    public class EditUsersName
    {
        [Required]
        public string Name { get; set; }
    }
    public class EditUsersEmail
    {
        [Required]
        public string Email { get; set; }
    }
    public class EditUsersPhone
    {
        [Required]
        public string Phone { get; set; }
    }
}