using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.GraphQL.Commands
{
    public record AddCommandInput(string CommandLine, string HowTo, int PlatformId);
}
