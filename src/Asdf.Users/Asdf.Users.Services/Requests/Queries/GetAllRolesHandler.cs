using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetAllRolesHandler 
        : IRequestHandler<GetAllRolesQuery, List<Role>>
    {
        private readonly IUserRepository _userService;

        public GetAllRolesHandler(
            IUserRepository userService)
        {
            _userService = userService;
        }

        public async Task<List<Role>> Handle(
            GetAllRolesQuery request, 
            CancellationToken cancellationToken)
        {
            return await this._userService.GetAllRoles().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}