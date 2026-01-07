namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;

public record RegisterUserDto(
    string Email,
    string Password,
    string Pronouns
);