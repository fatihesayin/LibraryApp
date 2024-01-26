# LibraryApp

## Pre Requisites

Visual Studio Code (Visual Studio, Rider etc.) with the C# extension installed.
The .NET 8 SDK needs to be downloaded also.

## Before Running The Application

Need to install PostgreSQL

### Determining Database 
Our Database Managemenent System is PostgreSQL 
Open LibraryApp.Api
Open appsettings.json

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