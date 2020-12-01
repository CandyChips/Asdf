using System;
using System.Collections.Generic;
using MediatR;

namespace Asdf.UserDomain.Services.Requests.Commands
{
    public class UplateUsersPhoneCommand 
        : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
    }
}