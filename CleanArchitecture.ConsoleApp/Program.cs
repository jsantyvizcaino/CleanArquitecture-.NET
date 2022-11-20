using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.AccessControl;
/*
StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMetHods();
await MultipleEntitiesQuery();


async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(v => v.Actores).FirstOrDefaultAsync(q => q.Id == 1);
    //var actor = await dbContext!.Actor!.Select(q => q.Nombre).ToListAsync();
    var videoWithDirector = await dbContext!.Videos!
        .Where(q=>q.Directores!=null)
        .Include(v => v.Directores)
        .Select(q => new
                     {
                           Director_Nombre = $"{q.Directores.Nombre} {q.Directores.Apellido}",
                           Movie = q.Nombre
                     }
               )
        .ToListAsync();
    foreach(var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre}");
    }

}
async Task AddNewDirectorWithVideo()
{
    
    var director = new Director { Nombre = "Lorenzo", Apellido = "Basteri",VideoId=1 };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor { Nombre = "Brat", Apellido = "Pit" };
    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();
    var videoActor = new VideoActor { ActorId = actor.Id, VideoId = 1 };
    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideoId()
{
    
    var pelicual = new Video { Nombre = "Leyenda", StreamerId = 1 };

    await dbContext.AddAsync(pelicual);
    await dbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer { Nombre = "Pantalla" };
    var pelicual = new Video { Nombre = "Hunger Games", Streamer = pantalla };

    await dbContext.AddAsync(pelicual);
    await dbContext.SaveChangesAsync();
}
async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNOTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2); //no almacena el objeto en memoria temporal x lo q no se puee actualizar

    streamerWithTracking.Nombre = "Netflix lite";
    streamerWithNOTracking.Nombre = "Amazon prime";

    await dbContext.SaveChangesAsync();
}
async Task QueryLink()
{

}
async Task QueryMetHods()
{
    var streamer = dbContext!.Streamers!;
    
    var firstAsync = await streamer.Where(x=>x!.Nombre!.Contains("a")).FirstAsync();
    
    var firstOrDefaultAsync = await streamer.Where(x=>x!.Nombre!.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaultAsync_v2 = await streamer.FirstOrDefaultAsync(x => x!.Nombre!.Contains("a"));
    
    var singleAsync = await streamer.SingleAsync(x => x.Id==1);
    var singleOrDefaultAsync = await streamer.SingleOrDefaultAsync(x => x.Id == 1);

    var resultado = await streamer.FindAsync(1);

    Console.WriteLine($"{firstAsync}");
    Console.WriteLine($"{firstOrDefaultAsync}");
}
async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compania de streaming: ");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where((x) => x!.Nombre!.Equals(streamingNombre)).ToListAsync();
    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamersPartialResults = await dbContext!.Streamers!.Where(x=>x!.Nombre!.Contains(streamingNombre)).ToListAsync();
    var streamersPartialResults = await dbContext!.Streamers!.Where(x=>EF.Functions.Like(x!.Nombre!,$"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamersPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
void QueryStreaming()
{
    var stramers = dbContext!.Streamers!.ToList();
    foreach(var streamer in stramers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney +",
        Url = "https://www.disney.com"
    };


    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video
        {
            Nombre="Arnold",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre="El camino hacia el dorado",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre="La sirenita",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre="Star Wars",
            StreamerId = streamer.Id,
        },

    };

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}*/