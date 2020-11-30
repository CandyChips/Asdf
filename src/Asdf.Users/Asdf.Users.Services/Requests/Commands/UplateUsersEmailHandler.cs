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
        private readonly IUserRepository _userRepository;

        public UplateUsersEmailHandler(
            IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<bool> Handle(
            UplateUsersEmailCommand request, 
            CancellationToken cancellationToken)
        {
            var user = await this._userRepository.GetUserByIdAsync(request.Id);
            user.EmailConfirmed = false;
            user.Email = request.Email;
            this._userRepository.UpdateUserAsync(user);
            return true;
        }
    }
}