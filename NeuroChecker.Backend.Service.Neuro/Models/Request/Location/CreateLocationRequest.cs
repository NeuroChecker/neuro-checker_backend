using System.ComponentModel.DataAnnotations;
using NeuroChecker.Backend.Service.Neuro.Enums;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Location;

public class CreateLocationRequest
{
    [Required] public long Latitude { get; set; }
    [Required] public long Longitude { get; set; }
    [Required] public LocationZoneType Type { get; set; }
}