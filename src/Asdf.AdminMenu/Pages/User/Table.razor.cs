using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Table
    {
        [Inject] private HttpClient Http { get; set; }
        private UserDto[] _users;
        private string _requestStatus = "Загрузка...";
        protected override async Task OnInitializedAsync()
        {
            await this.LoadData();
        }

        protected async Task LoadData()
        {
            var result = await Http.GetAsync("https://localhost:5001/api/users/User/GetAllUsers");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _users = await result.Content.ReadFromJsonAsync<UserDto[]>();
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode}";
            }
        }
    
        public class UserDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}