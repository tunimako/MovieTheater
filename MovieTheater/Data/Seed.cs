using MovieTheater.Data.Enums;
using MovieTheater.Models;

namespace MovieTheater.Data
{

    public static class Seed
    {
        public static void SeedData(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieTheaterDbContext>();

                context.Database.EnsureCreated();
                if (!context.Company.Any())
                {
                    Company comapny = new Company();
                    context.Company.Add(comapny);

                    Cinema kaunasForum = new Cinema("KaunasForum", 8, 00, 23, 45)
                    {
                        Address = new Address("Kaunas", "Mindaugo pr.", "49", "Lietuva"),
                        Company = comapny,
                        CinemaHalls = new List<CinemaHall>()
                            {
                                new CinemaHall(50),
                                new CinemaHall(60),
                                new CinemaHall(35),
                                new CinemaHall(2)
                            }
                    };
                    Cinema vilniusForum = new Cinema("VilniusForum", 7, 00, 00, 30)
                    {
                        Address = new Address("Vilnius", "Savanorių pr.", "7", "Lietuva"),
                        Company = comapny,
                        CinemaHalls = new List<CinemaHall>()
                            {
                                new CinemaHall(100),
                                new CinemaHall(120),
                                new CinemaHall(50),
                                new CinemaHall(5)
                            }
                    };
                    Cinema klaipedaForum = new Cinema("KlaipėdaForum", 8, 30, 23, 45)
                    {
                        Address = new Address("Klaipėda", "Taikos pr.", "61", "Lietuva"),
                        Company = comapny,
                        CinemaHalls = new List<CinemaHall>()
                            {
                                new CinemaHall(99),
                                new CinemaHall(30),
                                new CinemaHall(60),
                                new CinemaHall(40)
                            }
                    };
                    context.Cinemas.AddRange(new List<Cinema>() { kaunasForum, vilniusForum, klaipedaForum });

                context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie("The Dark Knight", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 9.0, new TimeSpan(2, 32, 00), AgeRating.N13)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Action),
                                new MovieGenre(Genre.Crime)
                            }
                        },
                        new Movie("Pulp Fiction", "The lives of two mob hitmen, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 8.9, new TimeSpan(2, 34, 00), AgeRating.N16)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Crime)
                            }
                        },
                        new Movie("Fight Club", "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.", 8.8, new TimeSpan(2, 19, 00), AgeRating.N16)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                            }
                        },
                        new Movie("Inception", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", 8.8, new TimeSpan(2, 28, 00), AgeRating.N13)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Action),
                                new MovieGenre(Genre.Adventure),
                                new MovieGenre(Genre.ScienceFiction)
                            }
                        },
                        new Movie("Avatar: The Way of Water", "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home.", 7.9, new TimeSpan(3, 12, 00), AgeRating.N7)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Action),
                                new MovieGenre(Genre.Adventure),
                                new MovieGenre(Genre.Fantasy)
                            }
                        },
                        new Movie("M3GAN", "A robotics engineer at a toy company builds a life-like doll that begins to take on a life of its own.", 6.6, new TimeSpan(1, 42, 00), AgeRating.N16)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Horror),
                                new MovieGenre(Genre.Thriller),
                                new MovieGenre(Genre.ScienceFiction)
                            }
                        },
                        new Movie("A Man Called Otto", "Otto is a grump who's given up on life following the loss of his wife and wants to end it all. When a young family moves in nearby, he meets his match in quick-witted Marisol, leading to a friendship that will turn his world around.", 7.6, new TimeSpan(2, 06, 00), AgeRating.V)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Comedy)
                            }
                        },
                        new Movie("Forrest Gump", "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", 8.8, new TimeSpan(2, 22, 00), AgeRating.N7)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Romance)
                            }
                        },
                        new Movie("Seven", "Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.", 8.6, new TimeSpan(2, 07, 00), AgeRating.N16)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Crime),
                                new MovieGenre(Genre.Mystery)
                            }
                        },
                        new Movie("Spirited Away", "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.", 8.6, new TimeSpan(2, 05, 00), AgeRating.V)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Animation),
                                new MovieGenre(Genre.Adventure)
                            }
                        },
                        new Movie("Back to the Future", "Marty McFly, a 17-year-old high school student, is accidentally sent 30 years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.", 8.5, new TimeSpan(1, 56, 00), AgeRating.N7)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Adventure),
                                new MovieGenre(Genre.Comedy),
                                new MovieGenre(Genre.ScienceFiction)
                            }
                        },
                        new Movie("Gladiator", "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", 8.5, new TimeSpan(2, 35, 00), AgeRating.N13)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Action),
                                new MovieGenre(Genre.Adventure),
                                new MovieGenre(Genre.Drama)
                            }
                        }
                    });
                context.Clients.AddRange(new List<Client>()
                    {
                        new Client("Haris", "Burokas", new DateTime(1998,10,25),"HarBur", "Haris123"),
                        new Client("Beata", "Karkauskaitė", new DateTime(2008,05,16),"BetKar", "Beata123")
                    });

                context.ShowTimes.AddRange(new List<ShowTime>()
                    {
                        new ShowTime(new DateTime(2023, 01, 22, 18, 20, 00))
                        {
                            Movie = new Movie("The Shawshank Redemption", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", 9.3, new TimeSpan(2,22,00), AgeRating.N13)
                            {
                                MovieGenres= new List<MovieGenre>()
                                {
                                    new MovieGenre(Genre.Drama)
                                }
                            },
                            CinemaHall = kaunasForum.CinemaHalls.First(),
                            Cinema = kaunasForum
                        },
                        new ShowTime(new DateTime(2023, 01, 23, 16, 00, 00))
                        {
                            Movie = new Movie("The Godfather", "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.", 9.2, new TimeSpan(2, 55, 00), AgeRating.N16)
                            {
                                MovieGenres = new List<MovieGenre>()
                                {
                                    new MovieGenre(Genre.Drama),
                                    new MovieGenre(Genre.Crime)
                                }
                            },
                            CinemaHall = vilniusForum.CinemaHalls.First(),
                            Cinema = vilniusForum
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
