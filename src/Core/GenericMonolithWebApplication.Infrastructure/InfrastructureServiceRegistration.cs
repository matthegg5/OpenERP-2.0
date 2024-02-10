
using GenericMonolithWebApplication.Application.Contracts.Infrastructure;
using GenericMonolithWebApplication.Infrastructure.FileExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenericMonolithWebApplication.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
                services.AddTransient<ICsvExporter, CsvExporter>();
                return services;
        }
    }
}