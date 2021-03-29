# Amadeus Hotel
## A small engine to search the hotel

Technologies:
- .Net Core 3.1
- MSSQL db

## Instructions for setting up the project:
API:
- Registration on: https://developers.amadeus.com/self-service/category/hotel/api-doc/hotel-search
- Change "AppSetings.AmadeusApi.APIKey" & "APISecret" with yours from registration
- Change ConnectionString to your local MSSQL server or to a hosted one
- Run the "Update-Database" command in the "Package Manager Console" to apply migrations

WEB:
- Change "AppSetings.ApiUrl" with your API address

Enjoy!
