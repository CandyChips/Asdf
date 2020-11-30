using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Create
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager UriHelper { get; set; }
        CreateUser User = new CreateUser();
        [Parameter] public RoleDto[] Roles { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Roles = await Http.GetFromJsonAsync<RoleDto[]>("https://localhost:5001/User/GetAllRoles");
        }
        async Task CreateUser()
        {
            Http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            var result = await Http.PostAsJsonAsync("https://localhost:5001/User/CreateUser", User);
            Http.DefaultRequestHeaders.Remove("x-requestid");
            if (result.StatusCode == HttpStatusCode.OK)
                UriHelper.NavigateTo("user/table");
        }
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

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}