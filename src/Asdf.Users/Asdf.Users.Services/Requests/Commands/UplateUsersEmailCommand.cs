using System;
using System.Collections.Generic;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class UplateUsersEmailCommand 
        : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}