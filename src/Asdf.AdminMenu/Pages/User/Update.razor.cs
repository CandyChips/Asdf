using System;
using System.ComponentModel.DataAnnotations;
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
        [Parameter] public string UserId { get; set; }
        [Parameter] public EditableUser _editableUser { get; set; }
        [Parameter] public EditUsersName _editUsersName { get; set; }
        [Parameter] public EditUsersEmail _editUsersEmail { get; set; }
        [Parameter] public string _requestStatus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this._requestStatus = "Загрузка...";
            var result = await Http.GetAsync($"https://localhost:5001/User/GetUser/Id={UserId}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _editableUser = await result.Content.ReadFromJsonAsync<EditableUser>();
                _editUsersName = new EditUsersName() { Name = _editableUser.Name, Id = this.UserId };
                _editUsersEmail = new EditUsersEmail() { Email = _editableUser.Email, Id = this.UserId };
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode}";
            }
        }
        async Task UpdateUsersName()
        {
            this._requestStatus = "Загрузка...";
            Http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            var result = await Http.PutAsJsonAsync("https://localhost:5001/User/UpdateUsersName", this._editUsersName);
            Http.DefaultRequestHeaders.Remove("x-requestid");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                UriHelper.NavigateTo("user/table");
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode}";
            }
        }
        async Task UpdateUsersEmail()
        {
            this._requestStatus = "Загрузка...";
            Http.DefaultRequestHeaders.Add("x-requestid", Guid.NewGuid().ToString());
            var result = await Http.PutAsJsonAsync("https://localhost:5001/User/UpdateUsersEmail", this._editUsersEmail);
            Http.DefaultRequestHeaders.Remove("x-requestid");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                UriHelper.NavigateTo("user/table");
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode}";
            }
        }
    }
    public class EditUsersName
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class EditUsersEmail
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class EditUsersPhone
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }

    public class EditableUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}