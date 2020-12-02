using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.Role;
using Asdf.AdminMenu.Models.User;
using Asdf.AdminMenu.Services;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Create
    {
        [Inject] private NavigationManager UriHelper { get; set; }
        [Inject] private IUserService UserService { get; set; }
        [Inject] private IRoleService RoleService { get; set; }
        CreateUser Form = new CreateUser();
        [Parameter] public RoleView[] Roles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await this.RoleService.GetAllRoles();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                Roles = await result.Content.ReadFromJsonAsync<RoleView[]>();
            }
            else
            {
            }
        }
        async Task CreateUser()
        {
            var result = await UserService.CreateUser(Form);
            if (result.StatusCode == HttpStatusCode.OK)
                UriHelper.NavigateTo("user/table");
        }
    }
}