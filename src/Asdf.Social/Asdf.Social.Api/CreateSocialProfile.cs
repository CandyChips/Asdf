using System;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Asdf.Social.Api.Commands
{
    
    public delegate IActorRef CreateSocialProfileActorProvider();
    public class CreateSocialProfileActor : ReceiveActor
    {
        private readonly ILogger<CreateSocialProfileActor> _logger;
        public CreateSocialProfileActor()
        {
            Receive<CreateSocialProfile>(greet =>
            {
                using (IServiceScope serviceScope = Context.CreateScope())
                {
                    var bookstoreContext = serviceScope.ServiceProvider.GetService<ILogger<CreateSocialProfileActor>>();
                    Sender.Tell(true);
                }
            });
        }
 
        protected override void PreStart() => _logger.LogInformation("Actor started");
     
        protected override void PostStop() => _logger.LogInformation("Actor stopped");
        
        public class CreateSocialProfile
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Guid CreatorId { get; set; }
        }
    }
}