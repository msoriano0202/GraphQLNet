using GraphQLDirector.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDirector.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Videos)
                .WithOne(d => d.Director)
                .HasForeignKey(d => d.DirectorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Video>? Videos { get; set; }
        public virtual DbSet<Director>? Directores { get; set; }
        public virtual DbSet<Streamer>? Streamers { get; set; }
    }
}
