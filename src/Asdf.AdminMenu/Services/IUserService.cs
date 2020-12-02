using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Asdf.AdminMenu.Models.User;

namespace Asdf.AdminMenu.Services
{
    public interface IUserService
    {
        Task<HttpResponseMessage> GetAllUsers();
        Task<HttpResponseMessage> GetUserById(Guid guid);
        Task<HttpResponseMessage> CreateUser(CreateUser createUser);
        Task<HttpResponseMessage> EditUsersName(EditUsersName editUsersName);
        Task<HttpResponseMessage> EditUsersEmail(EditUsersEmail editUsersEmail);
        Task<HttpResponseMessage> EditUsersPhone(EditUsersPhone editUsersPhone);
    }
}