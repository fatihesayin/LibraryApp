# LibraryApp

## Pre-Requisites

Need to install PostgreSQL Server
Visual Studio Code (Visual Studio, Rider etc.) with the C# extension installed.
The .NET 8 SDK needs to be downloaded also.

## Before Running The Application

### Determining Database 
Our Database Managemenent System is PostgreSQL 
Open LibraryApp.Api
Open appsettings.json
    "DefaultConnection": "Host={host:port};Database=LibraryManagement;Username={Username};Password={Password};"
Replace host:port with your own Database Host And Port (Default is localhost:5432)
Replace Username as your own Database Username (Default is postgres)
If you identified password then
    Replace Password as your own Database Password (Default is postgres)
Else 
    Password={Password}; part can be deleted

### Database Installation
On Terminal Run the following code snippets

```bash
cd LibraryApp.Api
```
Add Migration
```bash
dotnet ef migrations add LibraryApp -p ../LibraryApp.EntityFrameWorkCore/LibraryApp.EntityFrameWorkCore.csproj
```
Update Database
```bash
dotnet ef database update -p ../LibraryApp.EntityFrameWorkCore/LibraryApp.EntityFrameWorkCore.csproj
```

### Running The Application

Run with Run and Debug Action or if your terminal not on LibraryApp.Api 
```bash
cd LibraryApp.Api
```
```bash
dotnet run 
```
on Terminal