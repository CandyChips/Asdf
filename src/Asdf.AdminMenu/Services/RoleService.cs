using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.Role;

namespace Asdf.AdminMenu.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _http; 
        private readonly string _url = "https://localhost:5001/api/users/User";

        public RoleService(
            HttpClient http)
        {
            _http = http;
        }
        
        public async Task<HttpResponseMessage> GetAllRoles()
        {
            return await _http.GetAsync($"{this._url}/GetAllRoles");
        }

        public async Task<HttpResponseMessage> CreateRole(CreateRole createRole)
        {
            _http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            return await _http.PostAsJsonAsync($"{this._url}/CreateRole", createRole);
        }
    }
}