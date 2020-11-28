using System;
using Asdf.Users.Models.Entities;
using MediatR;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
    }
}