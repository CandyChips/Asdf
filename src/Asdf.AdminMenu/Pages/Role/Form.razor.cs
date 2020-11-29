using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Pages.Role;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.Role
{
    public partial class Form
    {
        [Inject] private HttpClient Http { get; set; }
        [Parameter] public CreateRole dev { get; set; }
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}