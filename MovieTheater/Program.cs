using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientShowtimeRepository, ClientShowtimeRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<ICinemaHallRepository, CinemaHallRepository>();
builder.Services.AddScoped<IShowtimeRepository, ShowtimeRepository>();
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
builder.Services.AddDbContext<MovieTheaterDbContext>(options =>
{
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging();
});

var app = builder.Build();

if (args.Length > 0 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
