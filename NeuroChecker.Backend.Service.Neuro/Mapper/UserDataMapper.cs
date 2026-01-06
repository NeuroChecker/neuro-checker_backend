using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.UserData;
using NeuroChecker.Backend.Service.Neuro.Models.Request.UserData;

namespace NeuroChecker.Backend.Service.Neuro.Mapper;

public static class UserDataMapper
{
    public static UserData ToFreshEntity(this CreateUserDataDto dot) => new()
    {
        UserId = dot.UserId,
        LocationId = dot.LocationId,

        Heartbeat = dot.Heartbeat,
        SoundIntensity = dot.SoundIntensity,
        BloodPressure = dot.BloodPressure,
        LightIntensity = dot.LightIntensity,

        CreatedAt = DateTime.UtcNow
    };

    public static GetUserDataDto ToGetDto(this UserData entity) => new(
        entity.Id,
        entity.UserId,
        entity.LocationId,
        entity.Heartbeat,
        entity.SoundIntensity,
        entity.BloodPressure,
        entity.LightIntensity,
        entity.CreatedAt
    );

    public static CreateUserDataDto ToCreateDto(this CreateUserDataRequest request, Guid userId, Guid locationId) => new(
        userId,
        locationId,
        request.Heartbeat,
        request.SoundIntensity,
        request.BloodPressure,
        request.LightIntensity
    );
    
    public static GetUserDataResponse ToResponse(this GetUserDataDto dto) => new(
        dto.Id,
        dto.UserId,
        dto.LocationId,
        dto.Heartbeat,
        dto.SoundIntensity,
        dto.BloodPressure,
        dto.LightIntensity,
        dto.CreatedAt
    );
}