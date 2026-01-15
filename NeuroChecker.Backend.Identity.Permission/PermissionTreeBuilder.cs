using System.Reflection;
using NeuroChecker.Backend.Identity.Permission.Models;

namespace NeuroChecker.Backend.Identity.Permission;

public static class PermissionTreeBuilder
{
    public static PermissionNode BuildTree(Type permissionType)
    {
        if (permissionType is null) throw new ArgumentNullException(nameof(permissionType));

        var root = new PermissionNode
        {
            Identifier = permissionType.Name,
            Key = null
        };

        foreach (var field in permissionType.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            if (field.FieldType != typeof(string)) continue;

            root.Children.Add(new PermissionNode
            {
                Identifier = field.Name,
                Key = field.GetValue(null) as string
            });
        }

        var types = permissionType.GetNestedTypes(BindingFlags.Public);
        foreach (var nestedType in types) root.Children.Add(BuildTree(nestedType));

        return root;
    }

    public static List<string> FlattenKeys(PermissionNode node)
    {
        var keys = new List<string>();
        if (node.Key is not null) keys.Add(node.Key);

        foreach (var child in node.Children)
        {
            keys.AddRange(FlattenKeys(child));
        }

        return keys;
    }
}