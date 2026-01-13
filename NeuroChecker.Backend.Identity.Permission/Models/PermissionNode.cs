namespace NeuroChecker.Backend.Identity.Permission.Models;

public class PermissionNode
{
    public string Identifier { get; init; } = null!;
    public string? Key { get; init; }
    
    public List<PermissionNode> Children { get; init; } = [];
}