namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;

public record CreateAcquaintanceDto(
    Guid UserId,
    Guid AcquaintanceId
);