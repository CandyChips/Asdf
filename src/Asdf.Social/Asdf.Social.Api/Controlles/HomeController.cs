using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Akka.Actor;
using Asdf.Social.Api.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Asdf.Social.Api.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IActorRef _createSocialProfileActor;
        public HomeController(
            CreateSocialProfileActorProvider createSocialProfileActorProvider)
        {
            this._createSocialProfileActor = createSocialProfileActorProvider();
        }
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpPost]
        [Route("CastActor")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CastActor(
            [FromBody] CreateSocialProfileActor.Command command, 
            [FromHeader(Name = "x-requestid")] Guid requestId)
        {
            command.NewId = Guid.NewGuid();
            var result = await this._createSocialProfileActor.Ask<CreateSocialProfileActor.Result>(command);
            return result.Errors.Any() ? (ActionResult) 
                BadRequest(result.Errors) : 
                Ok(result.Id);
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
