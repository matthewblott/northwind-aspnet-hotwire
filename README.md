# Northwind ASP.NET Hotwire

An example application based on the Northwind database using ASP.NET with Rails Hotwire.

The database uses Sqlite so it should be straightforward to run.

First make sure .NET 8.0 is insalled and build the main project:

```
dotnet build

```

Then make sure `npm` is installed and build the front end:

```
cd WebUI/ClientApp
npm install

```

Then start the front end dev server using Vite:

```
npm run dev
```

Finally start the main application:

```
dotnet run

```
