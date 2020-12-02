using System;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.Users.Services.Requests.Queries
{
    class GetUserByIdHandler 
        : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UserManager<User> _userManager;

        public GetUserByIdHandler(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> Handle(
            GetUserByIdQuery request, 
            CancellationToken cancellationToken)
        {
            return await this._userManager.FindByIdAsync(request.Id.ToString());
        }
    }
}