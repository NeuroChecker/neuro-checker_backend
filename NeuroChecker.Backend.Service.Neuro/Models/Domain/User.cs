using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NeuroChecker.Backend.Service.Neuro.Models.Domain;

public class User : IdentityUser<Guid>
{
    [Required, MaxLength(50)] public string Pronouns { get; set; } = null!;

    //  [Required] public string Photo { get; set; } = null!; // TODO - implement

    [Required] public double HeartbeatLimit { get; set; }
    [Required] public double HeartbeatDeviation { get; set; }

    [Required] public double SoundLimit { get; set; }
    [Required] public double SoundDeviation { get; set; }

    [Required] public double BloodLimit { get; set; }
    [Required] public double BloodDeviation { get; set; }

    [Required] public double LightLimit { get; set; }
    [Required] public double LightDeviation { get; set; }

    public ICollection<Acquaintance> Acquaintances { get; set; } = new List<Acquaintance>();
}