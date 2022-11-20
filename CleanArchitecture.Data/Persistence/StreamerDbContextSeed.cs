using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if(!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("se agregron nuevos datos a la bd {context}",typeof(StreamerDbContext).Name);

            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer{ CreatedBy="santiago",Nombre="HBO MAX",Url="http://www.hbomax.com"},
                new Streamer{ CreatedBy="santiago",Nombre="AMAZON MAX",Url="http://www.amazon.com"},
            };
        }
    }
}
