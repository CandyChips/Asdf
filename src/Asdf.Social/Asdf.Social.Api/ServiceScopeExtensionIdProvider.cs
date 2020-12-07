using Akka.Actor;

namespace Asdf.Social.Api
{
    public class ServiceScopeExtensionIdProvider : ExtensionIdProvider<ServiceScopeExtension>
    {
        public override ServiceScopeExtension CreateExtension(ExtendedActorSystem system)
        {
            return new ServiceScopeExtension();
        }

        public static ServiceScopeExtensionIdProvider Instance = new ServiceScopeExtensionIdProvider();
    }
}