
using OpenERP.Application.Contracts.Infrastructure;
using OpenERP.Infrastructure.FileExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OpenERP.Infrastructure
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