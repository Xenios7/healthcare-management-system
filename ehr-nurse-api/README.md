# 🩺 EHRNurse – Electronic Health Record System

EHRNurse is a .NET-based backend service for managing electronic health records (EHR), built with a clean architecture and Entity Framework Core for data persistence.

---

## 📁 Project Structure

- **`EHRNurse.Domain`** – Core business logic and domain models.
- **`EHRNurse.Data`** – Data access layer (Entity Framework Core, PostgreSQL).
- **`EHRNurse.Api`** – RESTful API endpoints (ASP.NET Core Web API).

---

## 🛠️ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or your target version)
- PostgreSQL database
- Basic familiarity with Entity Framework Core

---

## 🚀 Setup Instructions

### 1. Create the Solution

```bash
mkdir EHRNurse && cd EHRNurse
dotnet new sln -n EHRNurse
dotnet new classlib -n EHRNurse.Domain
dotnet new classlib -n EHRNurse.Data
dotnet new webapi -n EHRNurse.Api
```

### 2. Wire Up Projects

```bash
dotnet sln add EHRNurse.Domain EHRNurse.Data EHRNurse.Api
dotnet add EHRNurse.Data reference EHRNurse.Domain
dotnet add EHRNurse.Api reference EHRNurse.Data
```

### 3. Install EF Core Tooling (Dev Machine Only)

```bash
dotnet new tool-manifest
dotnet tool install dotnet-ef
```

### 4. Add NuGet Packages

```bash
# In EHRNurse.Data
cd EHRNurse.Data
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ..

# In EHRNurse.Api
cd EHRNurse.Api
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ..
```

### 5. Scaffold DbContext from Existing Database

```bash
cd EHRNurse.Data
dotnet ef dbcontext scaffold \
'Host=your-db-host;Port=5432;Database=your-db-name;Username=your-user;Password=your-password' \
  Npgsql.EntityFrameworkCore.PostgreSQL \
  -o Models \
  -c AppDbContext \
  --force
```
