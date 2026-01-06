namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.UserData;

public record GetUserDataDto(
    Guid Id,
    Guid UserId,
    Guid LocationId,
    double Heartbeat,
    double SoundIntensity,
    double BloodPressure,
    double LightIntensity,
    DateTime CreatedAt
);