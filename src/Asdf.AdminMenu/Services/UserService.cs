using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.User;

namespace Asdf.AdminMenu.Services
{
    class UserService
        : IUserService
    {
        private readonly HttpClient _http; 
        private readonly string _url = "https://localhost:5001/api/users/User";

        public UserService(
            HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> GetAllUsers()
        {
            return await _http.GetAsync($"{this._url}/GetAllUsers");
        }

        public async Task<HttpResponseMessage> GetUserById(Guid guid)
        {
            return await _http.GetAsync($"{this._url}/GetUser/Id={guid}");
        }

        public async Task<HttpResponseMessage> CreateUser(CreateUser createUser)
        {
            _http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            return await _http.PostAsJsonAsync($"{this._url}/CreateUser", createUser);
        }

        public async Task<HttpResponseMessage> EditUsersName(EditUsersName editUsersName)
        {
            return await _http.PutAsJsonAsync($"{this._url}/UpdateUsersName", editUsersName);
        }

        public async Task<HttpResponseMessage> EditUsersEmail(EditUsersEmail editUsersEmail)
        {
            return await _http.PutAsJsonAsync($"{this._url}/UpdateUsersEmail", editUsersEmail);
        }

        public async Task<HttpResponseMessage> EditUsersPhone(EditUsersPhone editUsersPhone)
        {
            return await _http.PutAsJsonAsync($"{this._url}/UpdateUsersPhone", editUsersPhone);
        }
    }
}