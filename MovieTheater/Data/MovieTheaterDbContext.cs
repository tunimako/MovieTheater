using Microsoft.EntityFrameworkCore;
using MovieTheater.Models;

namespace MovieTheater.Data
{
    public class MovieTheaterDbContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<ClientShowTime> ClientShowTimes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        
        public MovieTheaterDbContext(DbContextOptions<MovieTheaterDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<ClientShowTime>().HasKey(x => new
            {
                x.ClientId,
                x.ShowTimeId
            });

            model.Entity<Client>()
                 .HasMany(x => x.ClientShowTimes)
                 .WithOne(x => x.Client)
                 .HasForeignKey(x => x.ClientId);

            model.Entity<ShowTime>()
                 .HasMany(x => x.ClientShowTimes)
                 .WithOne(x => x.ShowTime)
                 .HasForeignKey(x => x.ShowTimeId);
        }
    }
}
