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
    public class GetAllUsersHandler 
        : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly UserManager<User> _userManager;

        public GetAllUsersHandler(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await this._userManager.Users.ToListAsync();
        }
    }
}