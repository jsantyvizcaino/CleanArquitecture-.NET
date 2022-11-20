using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        public StreamerDbContext(DbContextOptions<StreamerDbContext> options) :base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Data Source=localhost; Initial Catalog=Streamer; Integrated Security=True ;Encrypt=False")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
        //        LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate =DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(s => s.Videos)
                .WithOne(v => v.Streamer)
                .HasForeignKey(v => v.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Actores)
                .WithMany(a => a.Videos)
                .UsingEntity<VideoActor>(
                    va => va.HasKey(e => new { e.ActorId, e.VideoId })
                );

        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actor { get; set; }
        public DbSet<Director>? Director { get; set; }


    }
}
