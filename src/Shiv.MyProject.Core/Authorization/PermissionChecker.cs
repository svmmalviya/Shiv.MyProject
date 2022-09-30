using Abp.Authorization;
using Shiv.MyProject.Authorization.Roles;
using Shiv.MyProject.Authorization.Users;

namespace Shiv.MyProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
