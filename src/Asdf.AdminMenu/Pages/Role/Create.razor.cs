using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.Role;
using Asdf.AdminMenu.Pages.Role;
using Asdf.AdminMenu.Services;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.Role
{
    public partial class Create
    {
        [Inject] private NavigationManager UriHelper { get; set; }
        [Inject] private IRoleService RoleService { get; set; }
        public CreateRole Form = new CreateRole();
        
        protected override async Task OnInitializedAsync()
        {
        }
        
        async Task CreateRole()
        {
            var result = await this.RoleService.CreateRole(Form);
            if (result.StatusCode == HttpStatusCode.OK)
                UriHelper.NavigateTo("role/table");
        }
    }
}