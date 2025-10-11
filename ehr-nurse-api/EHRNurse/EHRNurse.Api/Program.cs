using EHRNurse.Data;
using EHRNurse.Data.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;


var builder = WebApplication.CreateBuilder(args);

// Add DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention()
);

// Program.cs, right after builder created:
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Using connection: {new Npgsql.NpgsqlConnectionStringBuilder(conn) { Password = "" }}");




builder.Services.AddControllers();


var app = builder.Build();
app.MapControllers();
app.Run();
