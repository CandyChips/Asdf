using System.Collections.Generic;
using Asdf.Users.Models.Entities;
using MediatR;

namespace Asdf.Users.Services.Requests.Queries
{
    public class GetAllRolesQuery 
        : IRequest<List<Role>> {}
}