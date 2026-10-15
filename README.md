# Products API

A .NET 8 Web API for managing products, organized into API, Application, Domain, and Infrastructure projects. It uses MediatR for commands and queries, FluentValidation for request validation, Entity Framework Core for persistence, and Serilog for structured logging.

## Run locally

Prerequisites: .NET 8 SDK and SQL Server LocalDB.

From the repository root:

```powershell
dotnet restore .\Products.sln
dotnet run --project .\Products.API\Products.API.csproj
```

The API uses the `ProductsDatabase` connection string in `Products.API/appsettings.json`. In Development, Swagger is available at `/swagger`. Serilog writes to the console and daily rolling files under `Products.API/logs/` when run from the project directory.

## Endpoints

```http
GET https://localhost:65102/api/products
GET https://localhost:65102/api/products/1
```

Create a product:

```http
POST https://localhost:65102/api/products
Content-Type: application/json

{
  "name": "Mechanical Keyboard",
  "price": 89.99
}
```

The HTTPS port may differ; check `Products.API/Properties/launchSettings.json`.
