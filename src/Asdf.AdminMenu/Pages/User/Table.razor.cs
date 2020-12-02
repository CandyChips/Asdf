using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Asdf.AdminMenu.Models.User;
using Asdf.AdminMenu.Services;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Table
    {
        [Inject] private IUserService UserService { get; set; }
        private UserView[] _users;

        protected override async Task OnInitializedAsync()
        {
            await this.LoadData();
        }

        protected async Task LoadData()
        {
            var result = await UserService.GetAllUsers();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _users = await result.Content.ReadFromJsonAsync<UserView[]>();
            }
        }
    }
}