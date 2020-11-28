using System;
using System.Linq;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;

namespace Asdf.Users.Services.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<Role> GetAllRoles();
        Task<User> GetUserByIdAsync(Guid id);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<Role> GetRoleByIdAsync(Guid id);
        Task CreateUserAsync(User user);
        void UpdateUserAsync(User user);
        void DeleteUserAsync(User user);
    }
}