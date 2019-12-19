using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Shopping_Card.Controllers
{
    public abstract class Shopping_CardControllerBase: AbpController
    {
        protected Shopping_CardControllerBase()
        {
            LocalizationSourceName = Shopping_CardConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
