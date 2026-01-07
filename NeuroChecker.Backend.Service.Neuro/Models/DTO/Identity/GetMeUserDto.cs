namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;

public record GetMeUserDto(
    string Email,
    string Pronouns,
    double HeartbeatLimit,
    double HeartbeatDeviation,
    double SoundLimit,
    double SoundDeviation,
    double BloodLimit,
    double BloodDeviation,
    double LightLimit,
    double LightDeviation
);