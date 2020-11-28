using Asdf.Users.Models.Entities;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Queries
{
    public class CreateUserQuery : IRequest
    {
        public User User { get; set; }
    }
}