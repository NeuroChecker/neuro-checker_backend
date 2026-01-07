using Microsoft.EntityFrameworkCore;

namespace NeuroChecker.Backend.Service.Neuro.Models.Domain;

[PrimaryKey(nameof(UserId), nameof(AcquaintanceId))]
public class Acquaintance
{
    public Guid UserId { get; init; }
    public Guid AcquaintanceId { get; init; }
}