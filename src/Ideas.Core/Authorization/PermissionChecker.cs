using Abp.Authorization;
using Ideas.Authorization.Roles;
using Ideas.Authorization.Users;

namespace Ideas.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
