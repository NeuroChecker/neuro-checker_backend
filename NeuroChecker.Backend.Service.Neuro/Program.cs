using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Identity.Permission;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Options;
using NeuroChecker.Backend.Service.Neuro.Repositories;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Services;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Statics;
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

builder.Services.AddAuthentication();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

builder.Services.AddAuthorization(options =>
{
    var tree = PermissionTreeBuilder.BuildTree(typeof(Permissions));
    var allKeys = PermissionTreeBuilder.FlattenKeys(tree);

    foreach (var key in allKeys)
    {
        options.AddPolicy(key, policy => policy.RequireClaim("permission", key));
    }
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IUserDataRepository, UserDataRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IDatabaseSetupService, DatabaseSetupService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(corsBuilder =>
        {
            corsBuilder.WithOrigins("http://localhost:3000")
                .WithHeaders("Content-Type", "Authorization", "Accept", "Origin", "X-Requested-With",
                    "X-SignalR-User-Agent")
                .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                .AllowCredentials();
        });
    });
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var setupService = scope.ServiceProvider.GetRequiredService<IDatabaseSetupService>();
    await setupService.EnsureDatabaseSetup();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseCors();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// TODO - Remove these default identity endpoints in favor of custom ones
var identityGroup = app.MapGroup("/auth");
identityGroup.MapIdentityApi<User>();

app.Run();

// docker run --name neuro_postgres -e POSTGRES_USER=neuro -e POSTGRES_DB=neuro -e POSTGRES_HOST_AUTH_METHOD=trust -p 5432:5432 -d postgres