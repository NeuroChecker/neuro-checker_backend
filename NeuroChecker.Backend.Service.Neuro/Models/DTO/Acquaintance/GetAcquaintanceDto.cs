namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;

// TODO - I don't think GET needs a DTO, since we already need to know both UserId and AcquaintanceId to query for it
// Same for UPDATE, only CREATE is* needed
public record GetAcquaintanceDto(
    Guid UserId,
    Guid AcquaintanceId
);