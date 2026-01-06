using NeuroChecker.Backend.Service.Neuro.Models.DTO.Location;

namespace NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

public interface ILocationRepository
{
    Task<GetLocationDto> CreateAsync(CreateLocationDto dto);

    Task<GetLocationDto?> GetByIdAsync(Guid id);

    Task<GetLocationDto?> UpdateAsync(UpdateLocationDto dto);
}