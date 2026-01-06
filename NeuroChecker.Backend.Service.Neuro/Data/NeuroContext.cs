using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeuroChecker.Backend.Service.Neuro.Models.Domain;

namespace NeuroChecker.Backend.Service.Neuro.Data;

public class NeuroContext(DbContextOptions<NeuroContext> options) : IdentityDbContext<User, Role, Guid>(options)
{
    public DbSet<Acquaintance> Acquaintances { get; set; } = null!;

    public DbSet<UserData> UserData { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
}