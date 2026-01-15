namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;

public record GetAcquaintanceDto(
    Guid Id,
    string Username,
    string Pronouns
);