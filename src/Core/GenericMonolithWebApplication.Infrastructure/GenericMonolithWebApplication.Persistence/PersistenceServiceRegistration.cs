#pragma warning disable CS8604 

using GenericMonolithWebApplication.Application.Contracts.Persistence;
using GenericMonolithWebApplication.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericMonolithWebApplication.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenericDbContext>(options => options.UseMySQL(configuration.GetConnectionString("GenericDbConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPartRepository, PartRepository>();

            return services;
        }
    }
}