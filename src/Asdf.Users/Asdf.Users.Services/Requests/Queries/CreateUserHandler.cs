using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Queries
{
    public class CreateUserHandler : IRequestHandler<CreateUserQuery>
    {
        private readonly IUserRepository _userService;

        public CreateUserHandler(IUserRepository userService)
        {
            _userService = userService;
        }
        public async Task<Unit> Handle(CreateUserQuery request, CancellationToken cancellationToken)
        {
           await _userService.CreateUserAsync(request.User);
           return new Unit();
        }
    }
}