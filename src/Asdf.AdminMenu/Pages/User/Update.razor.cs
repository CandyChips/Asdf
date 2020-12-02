using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.User;
using Asdf.AdminMenu.Services;
using Microsoft.AspNetCore.Components;

namespace Asdf.AdminMenu.Pages.User
{
    public partial class Update
    {
        [Inject] private IUserService UserService { get; set; }
        [Parameter] public string RouteId { get; set; }
        [Parameter] public UserView _editableUser { get; set; }
        [Parameter] public EditUsersName _editUsersName { get; set; }
        [Parameter] public EditUsersEmail _editUsersEmail { get; set; }
        [Parameter] public EditUsersPhone _editUsersPhone { get; set; }

         
        protected override async Task OnInitializedAsync()
        {
            await this.UpdateEditableUserAsync(Guid.Parse(RouteId));
        }

        private async Task UpdateEditableUserAsync(Guid id)
        {
            this._editableUser = null;
            var result = await this.UserService.GetUserById(id);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _editableUser = await result.Content.ReadFromJsonAsync<UserView>();
                _editUsersName = new EditUsersName() { Name = _editableUser.Name, Id = this._editableUser.Id };
                _editUsersEmail = new EditUsersEmail() { Email = _editableUser.Email, Id = this._editableUser.Id };
                _editUsersPhone = new EditUsersPhone() { Phone = _editableUser.Phone, Id = this._editableUser.Id };
            }
        }
        async Task UpdateUsersName()
        {
            this._editableUser = null;
            var result = await UserService.EditUsersName(_editUsersName);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(Guid.Parse(RouteId));
            }
        }
        async Task UpdateUsersEmail()
        {
            this._editableUser = null;
            var result = await UserService.EditUsersEmail(_editUsersEmail);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(Guid.Parse(RouteId));
            }
        }
        async Task UpdateUsersPhone()
        {
            this._editableUser = null;
            var result = await UserService.EditUsersPhone(_editUsersPhone);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                await this.UpdateEditableUserAsync(Guid.Parse(RouteId));
            }
        }
    }
}