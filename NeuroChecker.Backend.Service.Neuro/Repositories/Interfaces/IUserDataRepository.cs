using NeuroChecker.Backend.Service.Neuro.Models.DTO.UserData;

namespace NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

public interface IUserDataRepository
{
    Task<GetUserDataDto> CreateAsync(CreateUserDataDto dto);

    Task<List<GetUserDataDto>> GetAllByUserIdAsync(Guid userId);
}