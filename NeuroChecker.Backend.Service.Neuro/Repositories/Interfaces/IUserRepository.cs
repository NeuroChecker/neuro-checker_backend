using NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;

namespace NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<GetAcquaintanceDto>> GetAcquaintancesAsync(Guid userId);

    Task<bool> LinkAcquaintanceAsync(Guid userId, Guid acquaintanceId);

    Task<bool> UnlinkAcquaintanceAsync(Guid userId, Guid acquaintanceId);
}