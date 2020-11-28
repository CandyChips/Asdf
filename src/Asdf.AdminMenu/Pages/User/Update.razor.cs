using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Update
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager UriHelper { get; set; }
        
        Table.UserDto User = new Table.UserDto();
        
        private string _requestStatus = "Загрузка...";
        
        private EditUsersEmail _editUsersEmail;        
        private EditUsersPhone _editUsersPhone;      
        private EditUsersName _editUsersName;

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
}