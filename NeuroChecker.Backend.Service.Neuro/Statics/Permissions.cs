namespace NeuroChecker.Backend.Service.Neuro.Statics;

public static class Permissions
{
    public static class Personal
    {
        public static class Acquaintance
        {
            public const string Read = "personal.acquaintance.read";
            public const string Link = "personal.acquaintance.link";
            public const string Unlink = "personal.acquaintance.unlink";
        }

        public static class UserData
        {
            public const string Create = "personal.userdata.create";
            public const string Read = "personal.userdata.read";
        }

        public static class User
        {
            public const string UpdateThresholds = "personal.user.updatethresholds";
        }
    }
}