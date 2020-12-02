using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.Role;
using Asdf.AdminMenu.Services;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.Role
{
    public partial class Table
    {
        [Inject] private IRoleService RoleService { get; set; }
        private RoleView[] _roles;
        protected override async Task OnInitializedAsync()
        {
            await this.LoadData();
        }

        protected async Task LoadData()
        {
            var result = await this.RoleService.GetAllRoles();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _roles = await result.Content.ReadFromJsonAsync<RoleView[]>();
            }
        }
    }
}