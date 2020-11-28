using System;
using System.Collections.Generic;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class CreateRoleCommand 
        : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}