using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class UplateUsersPhoneHandler
        : IRequestHandler<UplateUsersPhoneCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public UplateUsersPhoneHandler(
            UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<bool> Handle(
            UplateUsersPhoneCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await this._userManager.FindByIdAsync(request.Id.ToString());
            var result = await this._userManager.SetUserNameAsync(user, request.Phone);
            if (result.Succeeded == false)
                return false;
            result = await this._userManager.SetPhoneNumberAsync(user, request.Phone);
            if (result.Succeeded == false)
                return false;
            return true;
        }
    }
}