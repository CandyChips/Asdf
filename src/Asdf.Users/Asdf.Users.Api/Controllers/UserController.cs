using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetClientNames(GetAllUsersQuery request)
        {
            try
            {
                var result = (await this._mediator.Send(request)).Select(c => c.UserName).ToList();
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