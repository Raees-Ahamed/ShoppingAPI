using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Shopping_Card.Authorization.Users;
using Shopping_Card.MultiTenancy;

namespace Shopping_Card
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Shopping_CardAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected Shopping_CardAppServiceBase()
        {
            LocalizationSourceName = Shopping_CardConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
