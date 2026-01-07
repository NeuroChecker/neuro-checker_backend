using System.ComponentModel.DataAnnotations;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;

public class UpdateThresholdsRequest
{
    // TODO - Check if these ranges are correct

    [Required, Range(0, 100)]
    public double HeartbeatLimit { get; set; }

    [Required, Range(0, 100)]
    public double HeartbeatDeviation { get; set; }

    [Required, Range(0, 100)]
    public double SoundLimit { get; set; }

    [Required, Range(0, 100)]
    public double SoundDeviation { get; set; }

    [Required, Range(0, 100)]
    public double BloodLimit { get; set; }

    [Required, Range(0, 100)]
    public double BloodDeviation { get; set; }

    [Required, Range(0, 100)]
    public double LightLimit { get; set; }

    [Required, Range(0, 100)]
    public double LightDeviation { get; set; }
}