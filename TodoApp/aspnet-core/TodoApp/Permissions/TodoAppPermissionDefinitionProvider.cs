// src/Acme.TodoApp.Domain/Permissions/TodoAppPermissionDefinitionProvider.cs
using TodoApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TodoApp.Permissions
{
    public class TodoAppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TodoAppPermissions.GroupName);

            var todoPermission = myGroup.AddPermission(TodoAppPermissions.Todos.Default, L("Permission:Todos"));
            todoPermission.AddChild(TodoAppPermissions.Todos.Create, L("Permission:Todos.Create"));
            todoPermission.AddChild(TodoAppPermissions.Todos.Delete, L("Permission:Todos.Delete"));
            todoPermission.AddChild(TodoAppPermissions.Todos.View, L("Permission:Todos.View"));
            todoPermission.AddChild(TodoAppPermissions.Todos.Manage, L("Permission:Todos.Manage"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TodoAppResource>(name);
        }
    }
}
