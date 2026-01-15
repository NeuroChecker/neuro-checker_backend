using NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;
using NeuroChecker.Backend.Service.Neuro.Models.Request.Acquaintance;

namespace NeuroChecker.Backend.Service.Neuro.Mapper;

public static class AcquaintanceMapper
{
    public static GetAcquaintanceResponse ToGetResponse(this GetAcquaintanceDto dto) => new(
        dto.Id,
        dto.Username,
        dto.Pronouns
    );
}