using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.Role
{
    public partial class Table
    {
        [Inject] private HttpClient Http { get; set; }
        private RoleDto[] _roles;
        private string _requestStatus = "Загрузка...";
        protected override async Task OnInitializedAsync()
        {
            await this.LoadData();
        }

        protected async Task LoadData()
        {
            var result = await Http.GetAsync("https://localhost:5001/User/GetAllRoles");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _roles = await result.Content.ReadFromJsonAsync<RoleDto[]>();
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode}";
            }
        }

        public class RoleDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}