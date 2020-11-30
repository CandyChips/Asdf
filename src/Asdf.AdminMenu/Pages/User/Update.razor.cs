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
        [Parameter] public string RouteId { get; set; }
        [Parameter] public EditableUser _editableUser { get; set; }
        [Parameter] public EditUsersName _editUsersName { get; set; }
        [Parameter] public EditUsersEmail _editUsersEmail { get; set; }
        [Parameter] public EditUsersPhone _editUsersPhone { get; set; }
        [Parameter] public string _requestStatus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await this.UpdateEditableUserAsync(Guid.Parse(RouteId));
        }

        private async Task UpdateEditableUserAsync(Guid id)
        {
            this._requestStatus = "Загрузка...";
            var result = await Http.GetAsync($"https://localhost:5001/User/GetUser/Id={id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _editableUser = await result.Content.ReadFromJsonAsync<EditableUser>();
                _editUsersName = new EditUsersName() { Name = _editableUser.Name, Id = this._editableUser.Id };
                _editUsersEmail = new EditUsersEmail() { Email = _editableUser.Email, Id = this._editableUser.Id };
                _editUsersPhone = new EditUsersPhone() { Phone = _editableUser.Phone, Id = this._editableUser.Id };
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
            var result = await Http.PutAsJsonAsync("https://localhost:5001/User/UpdateUsersName", this._editUsersName);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(_editableUser.Id);
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode.ToString()}";
            }
        }
        async Task UpdateUsersEmail()
        {
            this._requestStatus = "Загрузка...";
            var result = await Http.PutAsJsonAsync("https://localhost:5001/User/UpdateUsersEmail", this._editUsersEmail);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(_editableUser.Id);
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode.ToString()}";
            }
        }
        async Task UpdateUsersPhone()
        {
            this._requestStatus = "Загрузка...";
            var result = await Http.PutAsJsonAsync("https://localhost:5001/User/UpdateUsersPhone", this._editUsersPhone);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(_editableUser.Id);
                this._requestStatus = "";
            }
            else
            {
                _requestStatus = $"Ошибка: {result.StatusCode.ToString()}";
            }
        }
    }
    public class EditUsersName
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class EditUsersEmail
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class EditUsersPhone
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }

    public class EditableUser
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}