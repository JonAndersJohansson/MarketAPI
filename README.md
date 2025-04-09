# MarketAPI

Ett enkelt RESTful .NET Web API för att hantera annonser, bud och användare.

## Tekniker

- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server LocalHost
- AutoMapper
- Swagger / OpenAPI
- JsonPatch (PATCH-support)
- DTOs och lagerarkitektur (API → Services → DataAccessLayer)

## Projektstruktur

- `MarketAPI` – API-projekt med controllers och Swagger
- `Services` – Service-lager med affärslogik och DTO-hantering
- `DataAccessLayer` – Data-lager med modeller, DbContext, seeding och repository

## Funktionalitet

API:et stödjer följande endpoints för varje entitet: `Ad`, `Bid` och `User`.

### GET
– Hämta alla annonser
– Hämta specifik annons

### POST
– Skapa ny annons

### PUT
– Uppdatera annons (fullständig uppdatering)

### PATCH
– Delvis uppdatering av annons med JSON Patch

### DELETE
– Soft delete (IsActive sätts till false)


## Soft Delete

Alla entiteter (`Ad`, `Bid`, `User`) använder `IsActive` istället för hård radering.

## Testdata

Applikationen seedar automatiskt exempeldata vid uppstart:
- 2st Ads
- 2st Users
- 2st Bids

## Kom igång

1. Klona repot
2. Kör `dotnet build`
3. Starta applikationen (`F5` eller `dotnet run`)
4. Databasen skapas automatiskt med testdata
5. Swagger nås via: `https://localhost:<port>/swagger`

## Swagger / OpenAPI

Swagger är integrerat och visar alla endpoints.

- URL: `/swagger`
- Titel: `"MarketAPI"`
