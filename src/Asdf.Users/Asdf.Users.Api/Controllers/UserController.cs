﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Asdf.UserDomain.Services.Mappers;
using Asdf.UserDomain.Services.Requests.Commands;
using Asdf.Users.Agregates;
using Asdf.Users.Services.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Newtonsoft.Json;
using Asdf.UserDomain.Services.Contexts;

namespace Asdf.Users.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost]
        [AllowAnonymous]
        [Route("getToken")]
        [ProducesResponseType(typeof(LoginStateDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAsync([FromBody] GetUsersTokenQuery query)
        {
            try
            {
                var result = await this._mediator.Send(query);
                if (result.Errors != null)
                {
                    return Unauthorized(result.Errors);
                }
                var jwt = new JwtSecurityToken(
                    issuer: "MyAuthServer",
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: new List<Claim>(),
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var tokenString = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    access_token = tokenString,
                    login_user = JsonConvert.SerializeObject(result)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet] 
        [AllowAnonymous]
        [Route("GetAllUsers")]
        [ProducesResponseType(typeof(List<UserDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUsersQuery()
        {
            try
            {
                var query = new GetAllUsersQuery();
                var result = (await this._mediator.Send(query)).Select(c => 
                    c.MapTo<UserDto>()).ToList();
                return result.Any() ? (IActionResult) Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet] 
        [AllowAnonymous]
        [Route("GetAllRoles")]
        [ProducesResponseType(typeof(List<RoleDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllRolesQuery()
        {
            try
            {
                var query = new GetAllRolesQuery();
                var result = (await this._mediator.Send(query)).Select(c => 
                    c.MapTo<RoleDto>()).ToList();
                return result.Any() ? (IActionResult) Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpGet] 
        [AllowAnonymous]
        [Route("GetUser/Id={id}")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserByIdQuery(Guid id)
        {
            try
            {
                var query = new GetUserByIdQuery(id);
                var result = (await this._mediator.Send(query)).MapTo<UserDto>();
                return result != null ? (IActionResult) Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        
        [HttpPost] 
        [AllowAnonymous]
        [Route("CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserCommand(
            [FromBody]CreateUserCommand command, 
            [FromHeader(Name = "x-requestid")] Guid requestId)
        {
            try
            {
                command.Id = requestId;
                var result = await this._mediator.Send(command);
                return result == false ? (IActionResult) BadRequest() : Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        
        [HttpPut] 
        [AllowAnonymous]
        [Route("UpdateUsersName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UplateUsersNameCommand(
            [FromBody]UplateUsersNameCommand command)
        {
            try
            {
                var result = await this._mediator.Send(command);
                return result == false ? (IActionResult) BadRequest() : Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        
        [HttpPut] 
        [AllowAnonymous]
        [Route("UpdateUsersEmail")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UplateUsersEmailCommand(
            [FromBody]UplateUsersEmailCommand command)
        {
            try
            {
                var result = await this._mediator.Send(command);
                return result == false ? (IActionResult) BadRequest() : Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        
        [HttpPut] 
        [AllowAnonymous]
        [Route("UpdateUsersPhone")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UplateUsersPhoneCommand(
            [FromBody]UplateUsersPhoneCommand command)
        {
            try
            {
                var result = await this._mediator.Send(command);
                return result == false ? (IActionResult) BadRequest() : Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
        
        [HttpPost] 
        [AllowAnonymous]
        [Route("CreateRole")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRoleCommand(
            [FromBody]CreateRoleCommand command, 
            [FromHeader(Name = "x-requestid")] Guid requestId)
        {
            try
            {
                command.Id = requestId;
                var result = await this._mediator.Send(command);
                return result == false ? (IActionResult) BadRequest() : Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.ToString());
                return BadRequest();
            }
        }
    }
}