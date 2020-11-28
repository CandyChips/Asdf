using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetAllUsersHandler 
        : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userService;

        public GetAllUsersHandler(
            IUserRepository userService)
        {
            _userService = userService;
        }

        public async Task<List<User>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            return await this._userService.GetAllUsers().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}