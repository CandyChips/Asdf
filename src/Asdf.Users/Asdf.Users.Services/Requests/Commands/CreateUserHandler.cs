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

        public CreateUserHandler(
            UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> Handle(
            CreateUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = new User() { 
                Name = request.Name,
                Email = request.Email, 
                UserName = request.Phone.ToString(), 
                Deleted = false
            };
            var result = await this._userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            result = await this._userManager.AddToRolesAsync(user, request.Roles);
            return result.Succeeded;
        }
    }
}