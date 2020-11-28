using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using Asdf.Users.Services.Requests.Queries;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Queries
{
    public class GetUserByIdHandler: IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userService;

        public GetUserByIdHandler(IUserRepository userService)
        {
            _userService = userService;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request.Id);
        }
    }
}