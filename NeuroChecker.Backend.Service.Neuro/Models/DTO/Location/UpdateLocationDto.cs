using NeuroChecker.Backend.Service.Neuro.Enums;

namespace NeuroChecker.Backend.Service.Neuro.Models.DTO.Location;

public record UpdateLocationDto(
    long Latitude,
    long Longitude,
    LocationZoneType Type
);