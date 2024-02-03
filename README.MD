This project is intended to be a wireframe/starting place for future .NET projects and applications, using a "clean" and popular system architecture. 

Currently requires .NET 8.0 SDK to build and run.

Use the below command in the solution directory to add a migration:-

dotnet ef migrations add InitialCreate --project ./src/Core/GenericMonolithWebApplication.Infrastructure/GenericMonolithWebApplication.Persistence/GenericMonolithWebApplication.Persistence.csproj --startup-project ./src/API/GenericMonolithWebApplication.API/GenericMonolithWebApplication.API.csproj