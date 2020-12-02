using System;
using System.ComponentModel.DataAnnotations;

namespace Asdf.AdminMenu.Models.User
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    public class EditUsersName
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class EditUsersEmail
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class EditUsersPhone
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }
    
    public class CreateUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password {get;set;}
        [Required]
        public string Phone { get; set; }
    }
}