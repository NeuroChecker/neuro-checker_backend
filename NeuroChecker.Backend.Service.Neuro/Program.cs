using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Options;
using NeuroChecker.Backend.Service.Neuro.Repositories;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var databaseOptions = builder.Configuration.GetSection("Database").Get<DatabaseOptions>();
if (databaseOptions is null) throw new InvalidOperationException("Database options are not configured.");

var connectionString = $"Server={databaseOptions.Host};" +
                       $"Port={databaseOptions.Port};" +
                       $"Database={databaseOptions.Database};" +
                       $"User Id={databaseOptions.User};" +
                       $"Password={databaseOptions.Password};";

builder.Services.AddDbContext<NeuroContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddIdentityCore<User>().AddRoles<Role>().AddEntityFrameworkStores<NeuroContext>();
builder.Services.AddIdentityApiEndpoints<User>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserDataRepository, UserDataRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// docker run --name neuro_postgres -e POSTGRES_USER=neuro -e POSTGRES_DB=neuro -e POSTGRES_HOST_AUTH_METHOD=trust -p 5432:5432 -d postgres