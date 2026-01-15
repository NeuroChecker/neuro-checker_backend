using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Statics;

namespace NeuroChecker.Backend.Service.Neuro.Services;

public class DatabaseSetupService(
    ILogger<DatabaseSetupService> logger,
    NeuroContext context,
    RoleManager<Role> roleManager
) : IDatabaseSetupService
{
    public async Task EnsureDatabaseSetup()
    {
        if (!await context.Database.CanConnectAsync())
        {
            logger.LogError("Database connection failed, check your configuration.");
            return;
        }

        await context.Database.MigrateAsync();
        await EnsureRoles();
    }

    private async Task EnsureRoles()
    {
        foreach (var role in BuiltinRoles.All)
        {
            if (await roleManager.RoleExistsAsync(role.NormalizedName))
            {
                logger.LogInformation("Role {Role} already exists, skipping role creation.", role.Name);
                continue;
            }

            var result = await roleManager.CreateAsync(new Role { Name = role.Name });
            if (!result.Succeeded)
            {
                logger.LogError("Failed to create role {Role}", role.Name);
                continue;
            }

            var roleEntity = await roleManager.FindByNameAsync(role.NormalizedName);
            if (roleEntity is null)
            {
                logger.LogError("Failed to find role {Role}", role.Name);
                continue;
            }

            foreach (var permission in role.Permissions)
            {
                await roleManager.AddClaimAsync(roleEntity, new Claim("permission", permission));
            }

            logger.LogInformation("Role {Role} created successfully.", role.Name);
        }
    }
}