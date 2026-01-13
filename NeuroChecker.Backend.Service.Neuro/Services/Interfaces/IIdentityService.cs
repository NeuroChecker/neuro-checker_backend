using System.Security.Claims;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;

namespace NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

public interface IIdentityService
{
    Task<User?> GetUserByClaimsPrincipalAsync(ClaimsPrincipal principal);
    
    Task<bool> RegisterUserAsync(RegisterUserDto dto);

    Task<bool> LoginUserAsync(LoginUserDto dto);
    
    Task<bool> LogoutUserAsync(ClaimsPrincipal principal);

    Task<GetMeUserDto?> GetMeUserAsync(ClaimsPrincipal principal);
    
    Task<bool> UpdateUserThresholdsAsync(ClaimsPrincipal principal, UpdateUserThresholdsDto dto);
}