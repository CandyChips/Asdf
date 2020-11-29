using System;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Repositories.Interfaces;
using MediatR;

namespace Asdf.Users.Services.Requests.Queries
{
    class GetUserByIdHandler 
        : IRequestHandler<GetUserByIdQuery, User>
    {
        private IUserRepository _userRepository;

        public GetUserByIdHandler(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(
            GetUserByIdQuery request, 
            CancellationToken cancellationToken)
        {
            return await this._userRepository.GetUserByIdAsync(request.Id);
        }
    }
}