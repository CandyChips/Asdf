using System;
using System.Collections.Generic;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }
        public string Password {get;set;}
        public string Phone { get; set; }
    }
}