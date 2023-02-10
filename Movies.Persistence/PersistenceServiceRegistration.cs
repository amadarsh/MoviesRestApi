using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movies.Application.Respository;
using Movies.Persistence.Repository;

namespace Movies.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<SakilaContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(configuration.GetConnectionString("MySqlConnectionString"), serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFilmRepository, FilmRespository>();
            services.AddScoped<IActorRespository, ActorRepository>();

            return services;
        }
    }
}
