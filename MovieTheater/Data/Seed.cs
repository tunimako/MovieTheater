using MovieTheater.Data.Enums;
using MovieTheater.Models;
using MovieTheater.Models.Enums;

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
                        //new Movie("The Shawshank Redemption", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.", 9.3, new TimeSpan(2,22,00), AgeRating.N13)
                        //{
                        //    MovieGenres = new List<MovieGenre>()
                        //    {
                        //        new MovieGenre(Genre.Drama)
                        //    }
                        //},
                        //new Movie("The Godfather", "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.", 9.2, new TimeSpan(2, 55, 00), AgeRating.N16)
                        //{
                        //    MovieGenres = new List<MovieGenre>()
                        //    {
                        //        new MovieGenre(Genre.Drama),
                        //        new MovieGenre(Genre.Crime)
                        //    }
                        //},
                        new Movie("The Dark Knight", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", 9.0, new TimeSpan(2, 32, 00), AgeRating.N13)
                        {
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre(Genre.Drama),
                                new MovieGenre(Genre.Action),
                                new MovieGenre(Genre.Crime)
                            }
                        },
                        new Movie("Pulp Fiction", "The lives of two mob hitmen, a \r\n<!doctype html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <meta name=\"description\" content=\"\">\r\n    <meta name=\"author\" content=\"Mark Otto, Jacob Thornton, and Bootstrap contributors\">\r\n    <meta name=\"generator\" content=\"Hugo 0.108.0\">\r\n    <title>Carousel Template · Bootstrap v5.3</title>\r\n\r\n    <link rel=\"canonical\" href=\"https://getbootstrap.com/docs/5.3/examples/carousel/\">\r\n\r\n    \r\n\r\n    \r\n\r\n<link href=\"/docs/5.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD\" crossorigin=\"anonymous\">\r\n\r\n    <!-- Favicons -->\r\n<link rel=\"apple-touch-icon\" href=\"/docs/5.3/assets/img/favicons/apple-touch-icon.png\" sizes=\"180x180\">\r\n<link rel=\"icon\" href=\"/docs/5.3/assets/img/favicons/favicon-32x32.png\" sizes=\"32x32\" type=\"image/png\">\r\n<link rel=\"icon\" href=\"/docs/5.3/assets/img/favicons/favicon-16x16.png\" sizes=\"16x16\" type=\"image/png\">\r\n<link rel=\"manifest\" href=\"/docs/5.3/assets/img/favicons/manifest.json\">\r\n<link rel=\"mask-icon\" href=\"/docs/5.3/assets/img/favicons/safari-pinned-tab.svg\" color=\"#712cf9\">\r\n<link rel=\"icon\" href=\"/docs/5.3/assets/img/favicons/favicon.ico\">\r\n<meta name=\"theme-color\" content=\"#712cf9\">\r\n\r\n\r\n    <style>\r\n      .bd-placeholder-img {\r\n        font-size: 1.125rem;\r\n        text-anchor: middle;\r\n        -webkit-user-select: none;\r\n        -moz-user-select: none;\r\n        user-select: none;\r\n      }\r\n\r\n      @media (min-width: 768px) {\r\n        .bd-placeholder-img-lg {\r\n          font-size: 3.5rem;\r\n        }\r\n      }\r\n\r\n      .b-example-divider {\r\n        height: 3rem;\r\n        background-color: rgba(0, 0, 0, .1);\r\n        border: solid rgba(0, 0, 0, .15);\r\n        border-width: 1px 0;\r\n        box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15);\r\n      }\r\n\r\n      .b-example-vr {\r\n        flex-shrink: 0;\r\n        width: 1.5rem;\r\n        height: 100vh;\r\n      }\r\n\r\n      .bi {\r\n        vertical-align: -.125em;\r\n        fill: currentColor;\r\n      }\r\n\r\n      .nav-scroller {\r\n        position: relative;\r\n        z-index: 2;\r\n        height: 2.75rem;\r\n        overflow-y: hidden;\r\n      }\r\n\r\n      .nav-scroller .nav {\r\n        display: flex;\r\n        flex-wrap: nowrap;\r\n        padding-bottom: 1rem;\r\n        margin-top: -1px;\r\n        overflow-x: auto;\r\n        text-align: center;\r\n        white-space: nowrap;\r\n        -webkit-overflow-scrolling: touch;\r\n      }\r\n    </style>\r\n\r\n    \r\n    <!-- Custom styles for this template -->\r\n    <link href=\"carousel.css\" rel=\"stylesheet\">\r\n  </head>\r\n  <body>\r\n    \r\n<header>\r\n  <nav class=\"navbar navbar-expand-md navbar-dark fixed-top bg-dark\">\r\n    <div class=\"container-fluid\">\r\n      <a class=\"navbar-brand\" href=\"#\">Carousel</a>\r\n      <button class=\"navbar-toggler\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#navbarCollapse\" aria-controls=\"navbarCollapse\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">\r\n        <span class=\"navbar-toggler-icon\"></span>\r\n      </button>\r\n      <div class=\"collapse navbar-collapse\" id=\"navbarCollapse\">\r\n        <ul class=\"navbar-nav me-auto mb-2 mb-md-0\">\r\n          <li class=\"nav-item\">\r\n            <a class=\"nav-link active\" aria-current=\"page\" href=\"#\">Home</a>\r\n          </li>\r\n          <li class=\"nav-item\">\r\n            <a class=\"nav-link\" href=\"#\">Link</a>\r\n          </li>\r\n          <li class=\"nav-item\">\r\n            <a class=\"nav-link disabled\">Disabled</a>\r\n          </li>\r\n        </ul>\r\n        <form class=\"d-flex\" role=\"search\">\r\n          <input class=\"form-control me-2\" type=\"search\" placeholder=\"Search\" aria-label=\"Search\">\r\n          <button class=\"btn btn-outline-success\" type=\"submit\">Search</button>\r\n        </form>\r\n      </div>\r\n    </div>\r\n  </nav>\r\n</header>\r\n\r\n<main>\r\n\r\n  <div id=\"myCarousel\" class=\"carousel slide\" data-bs-ride=\"carousel\">\r\n    <div class=\"carousel-indicators\">\r\n      <button type=\"button\" data-bs-target=\"#myCarousel\" data-bs-slide-to=\"0\" class=\"active\" aria-current=\"true\" aria-label=\"Slide 1\"></button>\r\n      <button type=\"button\" data-bs-target=\"#myCarousel\" data-bs-slide-to=\"1\" aria-label=\"Slide 2\"></button>\r\n      <button type=\"button\" data-bs-target=\"#myCarousel\" data-bs-slide-to=\"2\" aria-label=\"Slide 3\"></button>\r\n    </div>\r\n    <div class=\"carousel-inner\">\r\n      <div class=\"carousel-item active\">\r\n        <svg class=\"bd-placeholder-img\" width=\"100%\" height=\"100%\" xmlns=\"http://www.w3.org/2000/svg\" aria-hidden=\"true\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><rect width=\"100%\" height=\"100%\" fill=\"#777\"/></svg>\r\n        <div class=\"container\">\r\n          <div class=\"carousel-caption text-start\">\r\n            <h1>Example headline.</h1>\r\n            <p>Some representative placeholder content for the first slide of the carousel.</p>\r\n            <p><a class=\"btn btn-lg btn-primary\" href=\"#\">Sign up today</a></p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"carousel-item\">\r\n        <svg class=\"bd-placeholder-img\" width=\"100%\" height=\"100%\" xmlns=\"http://www.w3.org/2000/svg\" aria-hidden=\"true\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><rect width=\"100%\" height=\"100%\" fill=\"#777\"/></svg>\r\n        <div class=\"container\">\r\n          <div class=\"carousel-caption\">\r\n            <h1>Another example headline.</h1>\r\n            <p>Some representative placeholder content for the second slide of the carousel.</p>\r\n            <p><a class=\"btn btn-lg btn-primary\" href=\"#\">Learn more</a></p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div class=\"carousel-item\">\r\n        <svg class=\"bd-placeholder-img\" width=\"100%\" height=\"100%\" xmlns=\"http://www.w3.org/2000/svg\" aria-hidden=\"true\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><rect width=\"100%\" height=\"100%\" fill=\"#777\"/></svg>\r\n        <div class=\"container\">\r\n          <div class=\"carousel-caption text-end\">\r\n            <h1>One more for good measure.</h1>\r\n            <p>Some representative placeholder content for the third slide of this carousel.</p>\r\n            <p><a class=\"btn btn-lg btn-primary\" href=\"#\">Browse gallery</a></p>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n    <button class=\"carousel-control-prev\" type=\"button\" data-bs-target=\"#myCarousel\" data-bs-slide=\"prev\">\r\n      <span class=\"carousel-control-prev-icon\" aria-hidden=\"true\"></span>\r\n      <span class=\"visually-hidden\">Previous</span>\r\n    </button>\r\n    <button class=\"carousel-control-next\" type=\"button\" data-bs-target=\"#myCarousel\" data-bs-slide=\"next\">\r\n      <span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span>\r\n      <span class=\"visually-hidden\">Next</span>\r\n    </button>\r\n  </div>\r\n\r\n\r\n  <!-- Marketing messaging and featurettes\r\n  ================================================== -->\r\n  <!-- Wrap the rest of the page in another container to center all the content. -->\r\n\r\n  <div class=\"container marketing\">\r\n\r\n    <!-- Three columns of text below the carousel -->\r\n    <div class=\"row\">\r\n      <div class=\"col-lg-4\">\r\n        <svg class=\"bd-placeholder-img rounded-circle\" width=\"140\" height=\"140\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 140x140\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#777\"/><text x=\"50%\" y=\"50%\" fill=\"#777\" dy=\".3em\">140x140</text></svg>\r\n        <h2 class=\"fw-normal\">Heading</h2>\r\n        <p>Some representative placeholder content for the three columns of text below the carousel. This is the first column.</p>\r\n        <p><a class=\"btn btn-secondary\" href=\"#\">View details &raquo;</a></p>\r\n      </div><!-- /.col-lg-4 -->\r\n      <div class=\"col-lg-4\">\r\n        <svg class=\"bd-placeholder-img rounded-circle\" width=\"140\" height=\"140\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 140x140\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#777\"/><text x=\"50%\" y=\"50%\" fill=\"#777\" dy=\".3em\">140x140</text></svg>\r\n        <h2 class=\"fw-normal\">Heading</h2>\r\n        <p>Another exciting bit of representative placeholder content. This time, we've moved on to the second column.</p>\r\n        <p><a class=\"btn btn-secondary\" href=\"#\">View details &raquo;</a></p>\r\n      </div><!-- /.col-lg-4 -->\r\n      <div class=\"col-lg-4\">\r\n        <svg class=\"bd-placeholder-img rounded-circle\" width=\"140\" height=\"140\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 140x140\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#777\"/><text x=\"50%\" y=\"50%\" fill=\"#777\" dy=\".3em\">140x140</text></svg>\r\n        <h2 class=\"fw-normal\">Heading</h2>\r\n        <p>And lastly this, the third column of representative placeholder content.</p>\r\n        <p><a class=\"btn btn-secondary\" href=\"#\">View details &raquo;</a></p>\r\n      </div><!-- /.col-lg-4 -->\r\n    </div><!-- /.row -->\r\n\r\n\r\n    <!-- START THE FEATURETTES -->\r\n\r\n    <hr class=\"featurette-divider\">\r\n\r\n    <div class=\"row featurette\">\r\n      <div class=\"col-md-7\">\r\n        <h2 class=\"featurette-heading fw-normal lh-1\">First featurette heading. <span class=\"text-muted\">It’ll blow your mind.</span></h2>\r\n        <p class=\"lead\">Some great placeholder content for the first featurette here. Imagine some exciting prose here.</p>\r\n      </div>\r\n      <div class=\"col-md-5\">\r\n        <svg class=\"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto\" width=\"500\" height=\"500\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 500x500\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#eee\"/><text x=\"50%\" y=\"50%\" fill=\"#aaa\" dy=\".3em\">500x500</text></svg>\r\n      </div>\r\n    </div>\r\n\r\n    <hr class=\"featurette-divider\">\r\n\r\n    <div class=\"row featurette\">\r\n      <div class=\"col-md-7 order-md-2\">\r\n        <h2 class=\"featurette-heading fw-normal lh-1\">Oh yeah, it’s that good. <span class=\"text-muted\">See for yourself.</span></h2>\r\n        <p class=\"lead\">Another featurette? Of course. More placeholder content here to give you an idea of how this layout would work with some actual real-world content in place.</p>\r\n      </div>\r\n      <div class=\"col-md-5 order-md-1\">\r\n        <svg class=\"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto\" width=\"500\" height=\"500\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 500x500\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#eee\"/><text x=\"50%\" y=\"50%\" fill=\"#aaa\" dy=\".3em\">500x500</text></svg>\r\n      </div>\r\n    </div>\r\n\r\n    <hr class=\"featurette-divider\">\r\n\r\n    <div class=\"row featurette\">\r\n      <div class=\"col-md-7\">\r\n        <h2 class=\"featurette-heading fw-normal lh-1\">And lastly, this one. <span class=\"text-muted\">Checkmate.</span></h2>\r\n        <p class=\"lead\">And yes, this is the last block of representative placeholder content. Again, not really intended to be actually read, simply here to give you a better view of what this would look like with some actual content. Your content.</p>\r\n      </div>\r\n      <div class=\"col-md-5\">\r\n        <svg class=\"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto\" width=\"500\" height=\"500\" xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" aria-label=\"Placeholder: 500x500\" preserveAspectRatio=\"xMidYMid slice\" focusable=\"false\"><title>Placeholder</title><rect width=\"100%\" height=\"100%\" fill=\"#eee\"/><text x=\"50%\" y=\"50%\" fill=\"#aaa\" dy=\".3em\">500x500</text></svg>\r\n      </div>\r\n    </div>\r\n\r\n    <hr class=\"featurette-divider\">\r\n\r\n    <!-- /END THE FEATURETTES -->\r\n\r\n  </div><!-- /.container -->\r\n\r\n\r\n  <!-- FOOTER -->\r\n  <footer class=\"container\">\r\n    <p class=\"float-end\"><a href=\"#\">Back to top</a></p>\r\n    <p>&copy; 2017–2022 Company, Inc. &middot; <a href=\"#\">Privacy</a> &middot; <a href=\"#\">Terms</a></p>\r\n  </footer>\r\n</main>\r\n\r\n\r\n    <script src=\"/docs/5.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN\" crossorigin=\"anonymous\"></script>\r\n\r\n      \r\n  </body>\r\n</html>\r\ner, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 8.9, new TimeSpan(2, 34, 00), AgeRating.N16)
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
                            CinemaHall = kaunasForum.CinemaHalls.First()
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
                            CinemaHall = vilniusForum.CinemaHalls.First()
                        }
                    });
                    //context.AddRange(new List<ShowTime>()
                    //{
                    //    new ShowTime(new DateTime(2023,01,22,18,20,00)),
                    //    new ShowTime(new DateTime(2023,01,23,16,00,00))
                    //});
                    context.SaveChanges();
                }
            }
        }
    }
}
