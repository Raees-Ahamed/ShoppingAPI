using Abp.Authorization;
using Shopping_Card.Authorization.Roles;
using Shopping_Card.Authorization.Users;

namespace Shopping_Card.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
