using System;
using Asdf.Users.Agregates;
using Asdf.Users.Models.Entities;
using MediatR;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetUsersTokenQuery
        : IRequest<LoginStateDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Destonation { get; set; }
    }
}