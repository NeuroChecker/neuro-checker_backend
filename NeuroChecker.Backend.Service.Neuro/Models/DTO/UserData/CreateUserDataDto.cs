namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.UserData;

public record CreateUserDataDto(
    Guid UserId,
    Guid LocationId,
    double Heartbeat,
    double SoundIntensity,
    double BloodPressure,
    double LightIntensity
);