using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_API.Data;
using GraphQL_API.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL_API.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represent any executable commands.");

            descriptor
                .Field(x => x.Platform)
                .ResolveWith<Resolvers>(x => x.GePlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform to which the command belongs");
        }

        private class Resolvers
        {
            public Platform GePlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(x=>x.Id == command.PlatformId);
            }
        }
    }
}
