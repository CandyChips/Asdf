using System;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Asdf.Users.Agregates;

namespace Asdf.Users.Services.Requests.Queries
{
    class GetUsersTokenHandler
        : IRequestHandler<GetUsersTokenQuery, LoginStateDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public GetUsersTokenHandler(
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginStateDto> Handle(
            GetUsersTokenQuery request, 
            CancellationToken cancellationToken)
        {
            var result = new LoginStateDto();
            var user = await this._userManager.FindByNameAsync(request.Login);
            if (user == null)
            {
                result.Errors.Add("Login incorrect");
                return result;
            }
            if (!await this._userManager.IsEmailConfirmedAsync(user))
            {
                result.Errors.Add("Verify email");
                return result;
            }
            if (!(await _signInManager.PasswordSignInAsync(request.Login, request.Password, false, false)).Succeeded)
            {
                result.Errors.Add("Password incorrect");
                return result;
            }
            result.Id = Guid.Parse(user.Id);
            return result;
        }
    }
}