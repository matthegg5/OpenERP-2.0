using OpenERP.Application;
using OpenERP.Infrastructure.Persistence;
using OpenERP.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OpenERP.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers();

            builder.Services.AddCors(options => 
                options.AddPolicy("open", policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ?? "https://localhost:7020",
                builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"])
                .AllowAnyMethod()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyHeader()
                .AllowCredentials()));

            builder.Services.AddSwaggerGen();

            builder.Logging.AddConsole();

            return builder.Build();
            
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");
            app.UseHttpsRedirection();
            app.MapControllers();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<OpenERPDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {
                //add logging
                throw;
            }
        }

        public static async Task MigrateAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<OpenERPDbContext>();
                if (context != null)
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {
                //add logging
                throw;
            }
        }
    }
}