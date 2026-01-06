namespace NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;

public record GetUserDataResponse(
    Guid Id,
    Guid UserId,
    Guid LocationId,
    double Heartbeat,
    double SoundIntensity,
    double BloodPressure,
    double LightIntensity,
    DateTime CreatedAt
);