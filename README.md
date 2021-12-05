# SQL on Air - Entity Framework Demo

This project uses Entity Framework to manage the database and access to
it through .NET.

## Resetting the Demo

If you've already run thee demo previously, you can follow these steps to reset the demo to
it's initial state.

1. Delete the `/EFWebApp/Migrations` folder to remove any existing entity framework infrastructure
2. Delete the ACME_DB database.
3. Make sure that the ConnectionString in `/EFWebApp/appsettings.json`
4. Make sure that the Conditional Compile Symbols includes a '_' at the end to start WITHOUT calculated fields, like this:
   `WITH_CALCULATED_FIELDS_`

## Getting Set Up.

The demo starts with just the basic, normalized model for Customers, Products, Orders and LineItems.

1. Generate the first migrations using powershell: 
   `./EFWebApp> dotnet ef migrations add v1`
2. Create and populate the database with some test cusomters, products and orders: 
   `./EFWebApp> dotnet ef database update`
3. Run the SQL on Air Desktop client to view the data
4. Update the Conditional Compile Symbols to remove the _ from the end of the field:
   `WITH_CALCULATED_FIELDS`
5. Create a new migration to define the calculated fields:
   `./EFWebApp> dotnet ef migrations add v2`
6. Update the database with the new fields
   `./EFWebApp> dotnet ef database update`
7. Use the SQL on Air Desktop Client to import the `/CalculatedFields.csv` file, and build the 
	SOA project in order to populate the DB with the triggers and stored procedures.	
8. Explore the new, DB with SQL on Air Desktop Client.





