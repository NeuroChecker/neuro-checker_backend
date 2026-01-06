using System.ComponentModel.DataAnnotations;

namespace NeuroChecker.Backend.Service.Neuro.Models.Domain;

public class UserData
{
    public Guid Id { get; init; }

    [Required] public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    [Required] public Guid LocationId { get; init; }
    public Location Location { get; init; } = null!;

    [Required] public double Heartbeat { get; init; }
    [Required] public double SoundIntensity { get; init; }
    [Required] public double BloodPressure { get; init; }
    [Required] public double LightIntensity { get; init; }

    [Required] public DateTime CreatedAt { get; init; }
}