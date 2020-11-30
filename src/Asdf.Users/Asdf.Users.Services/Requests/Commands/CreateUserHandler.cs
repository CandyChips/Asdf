using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class CreateUserHandler
        : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public CreateUserHandler(
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            this._userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Handle(
            CreateUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = new User() { 
                Name = request.Name,
                Email = request.Email, 
                EmailConfirmed = false,
                UserName = request.Phone,
                PhoneNumberConfirmed = false,
                PhoneNumber = request.Phone,
                Deleted = false
            };
            var result = await this._userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            result = await this._userManager.AddToRoleAsync(user, (await this._roleManager.FindByIdAsync(request.Role)).Name);
            return result.Succeeded;
        }
    }
}