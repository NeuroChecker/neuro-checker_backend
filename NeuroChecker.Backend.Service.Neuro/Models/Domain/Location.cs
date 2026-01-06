using System.ComponentModel.DataAnnotations;
using NeuroChecker.Backend.Service.Neuro.Enums;

namespace NeuroChecker.Backend.Service.Neuro.Models.Domain;

public class Location
{
    public Guid Id { get; init; }

    [Required] public long Latitude { get; init; }
    [Required] public long Longitude { get; init; }

    [Required] public LocationZoneType Type { get; init; }
}