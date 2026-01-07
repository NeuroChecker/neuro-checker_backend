using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Identity;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Location;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Identity;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Location;

namespace NeuroChecker.Backend.Service.Neuro.Mapper;

public static class LocationMapper
{
    public static Location ToFreshEntity(this CreateLocationDto dot) => new()
    {
        Latitude = dot.Latitude,
        Longitude = dot.Longitude,
        Type = dot.Type
    };

    public static GetLocationDto ToGetDto(this Location entity) => new(
        entity.Id,
        entity.Latitude,
        entity.Longitude,
        entity.Type
    );

    public static CreateLocationDto ToCreateDto(this CreateLocationRequest request) => new(
        request.Latitude,
        request.Longitude,
        request.Type
    );

    public static GetLocationResponse ToResponse(this GetLocationDto dto) => new(
        dto.Latitude,
        dto.Longitude,
        dto.Type
    );

    public static UpdateUserThresholdsDto ToUpdateThresholdsDto(this UpdateThresholdsRequest request) => new(
        request.HeartbeatLimit,
        request.HeartbeatDeviation,
        request.SoundLimit,
        request.SoundDeviation,
        request.BloodLimit,
        request.BloodDeviation,
        request.LightLimit,
        request.LightDeviation
    );
}