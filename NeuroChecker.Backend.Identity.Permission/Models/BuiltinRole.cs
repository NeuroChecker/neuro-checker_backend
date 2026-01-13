namespace NeuroChecker.Backend.Identity.Permission.Models;

public class BuiltinRole
{
    public string Name { get; init; } = null!;
    public string NormalizedName => Name.ToUpperInvariant();

    public List<string> Permissions { get; init; } = [];
}