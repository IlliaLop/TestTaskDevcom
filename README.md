This repository contains the TestTask application, a sample project designed to manage users and orders. The application is developed using ASP.NET Core and Entity Framework Core.
1. Configure Database Connection:
Open the appsettings.json file in the project root. Update the TestTaskDBConnection property with your database connection string:
"TestTaskDBConnection": "Server=localhost;Database=YourDatabaseName;User=YourUsername;Password=YourPassword;..."
2. Run Migrations:
Navigate to the project directory in a terminal and run the following commands to apply the database migrations:
dotnet ef migrations add InitialMigration
dotnet ef database update

Access the API documentation at /swagger after starting the application. It will look like this:
![image](https://github.com/IlliaLop/TestTaskDevcom/assets/118636435/5b3d164a-45b7-4661-9d95-1641042dadcf)
