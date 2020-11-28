using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Asdf.UserDomain.Services.Mappers;
using Asdf.Users.Agregates;
using Asdf.Users.Services.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Asdf.Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(
            ILogger<UserController> logger, 
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet] 
        [Route("GetAllUserNames")]
        [ProducesResponseType(typeof(List<UserDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetClientNames()
        {
            try
            {
                var query = new GetAllUsersQuery();
                var result = (await this._mediator.Send(query)).Select(c => 
                    c.Id).ToList();
                return result.Any() ? (IActionResult) Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}