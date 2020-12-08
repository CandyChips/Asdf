using System;
using System.Collections;
using System.Collections.Generic;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Asdf.Social.Api.Commands
{
    
    public delegate IActorRef CreateSocialProfileActorProvider();
    public class CreateSocialProfileActor : ReceiveActor
    {
        private ILogger _logger;
        public CreateSocialProfileActor()
        {
            ReceiveAsync<Command>(async command =>
            {
                var result = new Result() {Id = Guid.NewGuid(), Errors = new List<string>()};
                Sender.Tell(result);
            });
        }
        protected override bool AroundReceive(
            Receive receive, 
            object message)
        {
            using (IServiceScope serviceScope = Context.CreateScope())
            {
                this._logger = serviceScope.ServiceProvider.GetService<ILogger<CreateSocialProfileActor>>();
                return base.AroundReceive(receive, message);
            }
        }
        
        public class Command
        {
            public Guid NewId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Guid CreatorId { get; set; }
        }

        public class Result
        {
            public List<string> Errors { get; set; }
            public Guid Id { get; set; }
        }
    }
}