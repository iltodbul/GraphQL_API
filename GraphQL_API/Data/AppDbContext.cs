using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Platform> Platforms { get; set; }


    }
}
