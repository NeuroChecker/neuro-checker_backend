using NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;

namespace NeuroChecker.Backend.Service.Neuro.Services.Interfaces;

public interface IIdentityService
{
    Task<bool> RegisterUserAsync(RegisterUserDto dto);

    Task<bool> LoginUserAsync(LoginUserDto dto);

    Task<GetMeUserDto?> GetMeUserAsync(string email);
}