namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Acquaintance;

public record GetAcquaintanceResponse(
    Guid Id,
    string Username,
    string Pronouns
);