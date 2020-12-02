using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class UplateUsersEmailHandler
        : IRequestHandler<UplateUsersEmailCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public UplateUsersEmailHandler(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(
            UplateUsersEmailCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await this._userManager.FindByIdAsync(request.Id.ToString());
            var result = await this._userManager.SetEmailAsync(user, request.Email);
            if (result.Succeeded == false)
                return false;
            return true;
        }
    }
}