using System.Linq;
using Asdf.UserDomain.Models.Entities;

namespace Asdf.UserDomain.Services.Repositories.Interfaces
{
    interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        IQueryable<Role> GetAllRolesByUser(User User);
        IQueryable<User> GetAllUsersByRole(User User);
        Task<User> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(User User);
        Task UpdateUserAsync(User User);
        Task DeleteUserAsync(User User);
    }
}