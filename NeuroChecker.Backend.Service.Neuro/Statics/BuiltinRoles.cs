using System.Collections.Immutable;
using NeuroChecker.Backend.Identity.Permission.Models;

namespace NeuroChecker.Backend.Service.Neuro.Statics;

public static class BuiltinRoles
{
    public static readonly BuiltinRole Admin = new()
    {
        Name = "Admin",
        Permissions = []
    };

    public static readonly BuiltinRole User = new()
    {
        Name = "User",
        Permissions =
        [
            Permissions.Personal.Acquaintance.Link,
            Permissions.Personal.Acquaintance.Unlink,

            Permissions.Personal.UserData.Create,
            Permissions.Personal.UserData.Read,

            Permissions.Personal.User.UpdateThresholds
        ]
    };

    public static readonly ImmutableList<BuiltinRole> All = ImmutableList.Create(
        Admin,
        User
    );
}