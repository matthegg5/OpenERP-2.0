using OpenERP.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder
                .ConfigureServices()
                .ConfigurePipeline();

// delete the database and recreate each time using the migrations on app start-up
// FOR DEVELOPMENT PURPOSES ONLY
//await app.ResetDatabaseAsync();

//apply the outstanding migrations on startup
await app.MigrateAsync();

app.Run();
