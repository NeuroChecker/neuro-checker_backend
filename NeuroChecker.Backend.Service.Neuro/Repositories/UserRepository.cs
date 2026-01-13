using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Data;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;
using NeuroChecker.Backend.Service.Neuro.Models.DTO.Acquaintance;
using NeuroChecker.Backend.Service.Neuro.Repositories.Interfaces;

namespace NeuroChecker.Backend.Service.Neuro.Repositories;

public class UserRepository(NeuroContext contest) : IUserRepository
{
    public async Task<List<GetAcquaintanceDto>> GetAcquaintancesAsync(Guid userId)
    {
        var user = await contest.Users.AsNoTracking()
            .Include(u => u.Acquaintances)
            .ThenInclude(a => a.AcquaintanceUser)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null) return [];

        return user.Acquaintances
            .Select(a => new GetAcquaintanceDto(
                a.AcquaintanceUser.Id,
                a.AcquaintanceUser.UserName ?? string.Empty,
                a.AcquaintanceUser.Pronouns
            ))
            .ToList();
    }

    public async Task<bool> LinkAcquaintanceAsync(Guid userId, Guid acquaintanceId)
    {
        var user = await contest.Users.FindAsync(userId);
        var acquaintance = await contest.Users.FindAsync(acquaintanceId);

        if (user is null || acquaintance is null) return false;

        var acquaintanceLink = new Acquaintance()
        {
            UserId = userId,
            AcquaintanceId = acquaintanceId
        };

        contest.Acquaintances.Add(acquaintanceLink);
        await contest.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnlinkAcquaintanceAsync(Guid userId, Guid acquaintanceId)
    {
        var acquaintanceLink = await contest.Acquaintances.FindAsync(userId, acquaintanceId);
        if (acquaintanceLink is null) return false;

        contest.Acquaintances.Remove(acquaintanceLink);
        await contest.SaveChangesAsync();

        return true;
    }
}