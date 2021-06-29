using System.Linq;
using GraphQL_API.Data;
using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;
using GraphQL_API.GraphQL.Commands;
using GraphQL_API.GraphQL.Platforms;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
            [ScopedService] AppDbContext context)
        {
            var platform = new Platform { Name = input.Name };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDbContext context)
        {
            var command = new Command
            {
                CommandLine = input.CommandLine,
                HowTo = input.HowTo,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new DeleteCommandPayload(command);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteCommandPayload> DeleteCommandAsync(int id,
            [ScopedService] AppDbContext context)
        {
            var command = context.Commands.FirstOrDefault(x => x.Id == id);

            context.Commands.Remove(command);
            await context.SaveChangesAsync();

            return new DeleteCommandPayload(command);
        }
    }
}
