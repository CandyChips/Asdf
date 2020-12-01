using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class UplateUsersNameHandler
        : IRequestHandler<UplateUsersNameCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public UplateUsersNameHandler(
            UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> Handle(
            UplateUsersNameCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await this._userManager.FindByIdAsync(request.Id.ToString());
            user.Name = request.Name;
            return true;
        }
    }
}