using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Pages.Role;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.Role
{
    public partial class Create
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private NavigationManager UriHelper { get; set; }
        CreateRole _dev = new CreateRole();
        async Task CreateDeveloper()
        {
            Http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            var result = await Http.PostAsJsonAsync("https://localhost:5001/User/CreateRole", _dev);
            Http.DefaultRequestHeaders.Remove("x-requestid");
            if (result.StatusCode == HttpStatusCode.OK)
                UriHelper.NavigateTo("role/table");
        }
    }
}