using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Mapper;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.UserData;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Repositories;

public class UserDataRepository(NeuroContext context) : IUserDataRepository
{
    public async Task<GetUserDataDto> CreateAsync(CreateUserDataDto dto)
    {
        var entity = dto.ToFreshEntity();
        await context.UserData.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.ToGetDto();
    }

    public async Task<List<GetUserDataDto>> GetAllByUserIdAsync(Guid userId)
        => await context.UserData.AsNoTracking()
            .Where(ud => ud.UserId == userId)
            .Select(ud => ud.ToGetDto())
            .ToListAsync();
}