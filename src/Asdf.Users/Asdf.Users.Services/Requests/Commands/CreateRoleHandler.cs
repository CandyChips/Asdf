using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class CreateRoleHandler
        : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateRoleHandler(
            RoleManager<Role> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<bool> Handle(
            CreateRoleCommand request, 
            CancellationToken cancellationToken)
        {
            var role = new Role() { 
                Id = request.Id.ToString(),
                Name = request.Name,
            };
            var result = await this._roleManager.CreateAsync(role);
            return result.Succeeded;
        }
    }
}