using GraphQL_API.Data;
using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;
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
    }
}
