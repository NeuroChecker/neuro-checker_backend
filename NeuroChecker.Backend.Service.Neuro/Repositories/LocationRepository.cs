using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Location;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Repositories;

public class LocationRepository(NeuroContext context) : ILocationRepository
{
    public async Task<GetLocationDto> CreateAsync(CreateLocationDto dto)
    {
        var entity = dto.ToFreshEntity();
        context.Locations.Add(entity);
        await context.SaveChangesAsync();

        return entity.ToGetDto();
    }

    public async Task<GetLocationDto?> GetByIdAsync(Guid id)
        => (await context.Locations.AsNoTracking().FirstOrDefaultAsync(loc => loc.Id == id))?.ToGetDto();

    public Task<GetLocationDto?> UpdateAsync(UpdateLocationDto dto)
    {
        throw new NotImplementedException();
    }
}