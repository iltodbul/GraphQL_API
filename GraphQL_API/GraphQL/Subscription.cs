using GraphQL_API.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL_API.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}
