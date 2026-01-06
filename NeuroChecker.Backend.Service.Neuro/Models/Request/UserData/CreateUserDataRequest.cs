using System.ComponentModel.DataAnnotations;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Location;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;

public class CreateUserDataRequest
{
    [Required] public double Heartbeat { get; set; }
    [Required] public double SoundIntensity { get; set; }
    [Required] public double BloodPressure { get; set; }
    [Required] public double LightIntensity { get; set; }

    [Required] public CreateLocationRequest Location { get; set; } = null!;
}