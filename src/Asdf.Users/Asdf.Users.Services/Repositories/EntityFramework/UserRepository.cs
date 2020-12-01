using System;
using System.Linq;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Contexts;
using Asdf.Users.Services.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Services.Repositories.EntityFramework
{
    public class UserRepository : BaseEntityFrameworkRepository, IUserRepository 
    {
        public UserRepository(IDataAccelerator dataAccelerator) : base(dataAccelerator)
        {
        }

        public IQueryable<User> GetAllUsers()
        {
            return this.Context.Users;
        }

        public IQueryable<Role> GetAllRoles()
        {
            return this.Context.Roles;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await this.Context.FindAsync<User>(id.ToString());
        }

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await this.Context.Roles.Where(c => c.Name == roleName).FirstOrDefaultAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid id)
        {
            return await this.Context.FindAsync<Role>(id.ToString());
        }

        public async Task CreateUserAsync(User user)
        {
            await this.Context.Users.AddAsync(user);
        }

        public void UpdateUserAsync(User user)
        {
            this.Context.Update(user);
        }

        public void DeleteUserAsync(User user)
        {
            user.Deleted = true;
        }
    }

}
