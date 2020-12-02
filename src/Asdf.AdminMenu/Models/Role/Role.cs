using System;

namespace Asdf.AdminMenu.Models.Role
{
    public class RoleView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class CreateRole
    {
        public string Name { get; set; }
    }
}