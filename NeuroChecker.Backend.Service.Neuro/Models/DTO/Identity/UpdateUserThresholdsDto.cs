namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;

public record UpdateUserThresholdsDto(
    double HeartbeatLimit,
    double HeartbeatDeviation,
    double SoundLimit,
    double SoundDeviation,
    double BloodLimit,
    double BloodDeviation,
    double LightLimit,
    double LightDeviation
);