#pragma warning disable CS8604 

using GenericMonolithWebApplication.Application.Contracts.Persistence;
using GenericMonolithWebApplication.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GenericMonolithWebApplication.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenericDbContext>(options => options.UseMySQL(configuration.GetConnectionString("GenericDbConnectionString")));
            services.AddDbContext<IdentityDbContext>(options => options.UseMySQL(configuration.GetConnectionString("IdentityDbConnectionString")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDbContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPartRepository, PartRepository>();

            return services;
        }
    }
}