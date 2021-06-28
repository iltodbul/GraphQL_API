using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_API.Data;
using GraphQL_API.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL_API.GraphQL.Platforms
{
    public class PlatformType :ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represent any software of service that has a command line interface");

            descriptor.Field(x => x.LicenseKey).Ignore();

            descriptor
                .Field(x => x.Commands)
                .ResolveWith<Resolvers>(x => x.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for this platform.");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(x => x.PlatformId == platform.Id);
            }
        }
    }
}
