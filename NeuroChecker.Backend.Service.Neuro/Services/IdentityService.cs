using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;
using NeuroChecker.Backend.Service.Neuro.Services.Interfaces;
using NeuroChecker.Backend.Service.Neuro.Statics;

namespace NeuroChecker.Backend.Service.Neuro.Services;

public class IdentityService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ILogger<IdentityService> logger
) : IIdentityService
{
    public async Task<User?> GetUserByClaimsPrincipalAsync(ClaimsPrincipal principal)
        => await userManager.GetUserAsync(principal);

    public async Task<bool> RegisterUserAsync(RegisterUserDto dto)
    {
        var user = new User
        {
            UserName = dto.Email,
            Email = dto.Email,
            Pronouns = dto.Pronouns,

            HeartbeatLimit = 100.0,
            HeartbeatDeviation = 0.0,

            SoundLimit = 100.0,
            SoundDeviation = 0.0,

            BloodLimit = 100.0,
            BloodDeviation = 0.0,

            LightLimit = 100.0,
            LightDeviation = 0.0
        };

        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            logger.LogWarning(
                "User {Email} registration failed: {Errors}",
                dto.Email,
                string.Join(", ", result.Errors.Select(e => e.Description))
            );

            return false;
        }

        var roleResult = await userManager.AddToRoleAsync(user, BuiltinRoles.User.NormalizedName);
        if (!roleResult.Succeeded)
        {
            logger.LogWarning(
                "Adding user {Email} to role {Role} failed: {Errors}",
                dto.Email,
                BuiltinRoles.User.NormalizedName,
                string.Join(", ", roleResult.Errors.Select(e => e.Description))
            );
        }

        return true;
    }

    public async Task<bool> LoginUserAsync(LoginUserDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user is null) return false;

        var result = await signInManager.PasswordSignInAsync(user, dto.Password, false, false);
        if (result.Succeeded) return true;

        if (result.RequiresTwoFactor)
        {
            logger.LogInformation("User {Email} requires two-factor authentication.", dto.Email);
        }
        else if (result.IsLockedOut)
        {
            logger.LogWarning("User {Email} is locked out.", dto.Email);
        }
        else
        {
            logger.LogWarning("User {Email} login failed.", dto.Email);
        }

        return false;
    }

    public async Task<GetMeUserDto?> GetMeUserAsync(ClaimsPrincipal principal)
    {
        var user = await GetUserByClaimsPrincipalAsync(principal);
        if (user is null) return null;

        return new GetMeUserDto(
            user.Email ?? string.Empty,
            user.Pronouns,
            user.HeartbeatLimit,
            user.HeartbeatDeviation,
            user.SoundLimit,
            user.SoundDeviation,
            user.BloodLimit,
            user.BloodDeviation,
            user.LightLimit,
            user.LightDeviation
        );
    }

    public async Task<bool> UpdateUserThresholdsAsync(ClaimsPrincipal principal, UpdateUserThresholdsDto dto)
    {
        var user = await GetUserByClaimsPrincipalAsync(principal);
        if (user is null) return false;

        user.HeartbeatLimit = dto.HeartbeatLimit;
        user.HeartbeatDeviation = dto.HeartbeatDeviation;

        user.SoundLimit = dto.SoundLimit;
        user.SoundDeviation = dto.SoundDeviation;

        user.BloodLimit = dto.BloodLimit;
        user.BloodDeviation = dto.BloodDeviation;

        user.LightLimit = dto.LightLimit;
        user.LightDeviation = dto.LightDeviation;

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded) return true;

        logger.LogWarning(
            "User {Email} thresholds update failed: {Errors}",
            user.Email,
            string.Join(", ", result.Errors.Select(e => e.Description))
        );

        return false;
    }
}