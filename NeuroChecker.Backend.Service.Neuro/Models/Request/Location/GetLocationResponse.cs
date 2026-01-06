using NeuroChecker.Backend.Service.Neuro.Enums;

namespace NeuroChecker.Backend.Service.Neuro.Models.Request.Location;

public record GetLocationResponse(
    // Guid Id,
    long Latitude,
    long Longitude,
    LocationZoneType Type
);