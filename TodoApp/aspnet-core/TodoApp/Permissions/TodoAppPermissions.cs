namespace TodoApp.Permissions
{
    public static class TodoAppPermissions
    {
        public const string GroupName = "TodoApp";

        public static class Todos
        {
            public const string Default = GroupName + ".Todos";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string View = Default + ".View";
            public const string Manage = Default + ".Manage"; // Permiso para que los administradores puedan gestionar todos los items
        }
    }
}
