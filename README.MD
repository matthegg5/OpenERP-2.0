This project is intended to be a wireframe/starting place for future .NET projects and applications, using a "clean" and popular system architecture. 

Currently requires .NET 8.0 SDK to build and run.

Use the below command in the solution directory to add a migration:-

dotnet ef migrations add InitialCreate --project ./src/Core/OpenERP.Persistence/OpenERP.Persistence.csproj --startup-project ./src/API/OpenERP.API/OpenERP.API.csproj

Use the below command to apply the migrations to the database defined in the appsettings.json connection string.

dotnet ef database update --project ./src/Core/OpenERP.Persistence/OpenERP.Persistence.csproj --startup-project ./src/API/OpenERP.API/OpenERP.API.csproj

To run the application:-

dotnet run --project ./src/API/OpenERP.API/OpenERP.API.csproj
