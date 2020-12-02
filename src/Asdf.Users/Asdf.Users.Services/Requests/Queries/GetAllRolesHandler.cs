using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetAllRolesHandler 
        : IRequestHandler<GetAllRolesQuery, List<Role>>
    {
        private readonly RoleManager<Role> _roleManager;

        public GetAllRolesHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<Role>> Handle(
            GetAllRolesQuery request, 
            CancellationToken cancellationToken)
        {
            return await this._roleManager.Roles.ToListAsync();
        }
    }
}