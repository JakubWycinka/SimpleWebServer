### This project was created to meet the following expectations:
Create a pair of two simple cooperating applications:

The first application (backend):
- reads data from 2 or 3 sources of different types - switching sources based on a parameter from the configuration file (to change the source require restarting the application)

- data should be saved between successive launches of the application (within a given data source)

- provides data via endpoint

- provides methods for adding and deleting data

- information about all requests that reaches the application should be written to the text log

The second application (frontend)
- displays (in a simple form) the data downloaded from the first application

- allows adding new data and deleting selected entities

# Backend

This project was generated with [Visual Studio](https://www.visualstudio.com/en-us/downloads/) and uses [.Net Core 2.1](https://github.com/dotnet/core).

## Development server

Application uses [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/?tabs=aspnetcore2x#kestrel) as a web server, [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) as a SQL data source, to use SQL Server provide proper `connection string` in `application.json` and give permission to create database.
and [LiteDb](http://www.litedb.org/) as a NOSQL data source.

To run application with [Visual Studio](https://www.visualstudio.com/en-us/downloads/) press "Run" button. 

# Frontend

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.1.5.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files. Make sure that `applicationUrl` in `launchSettings.json` is the same as `apiUrlBase` in `environment.ts`.
