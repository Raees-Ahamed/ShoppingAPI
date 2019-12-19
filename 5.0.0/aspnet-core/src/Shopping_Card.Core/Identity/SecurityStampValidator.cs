using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Shopping_Card.Authorization.Roles;
using Shopping_Card.Authorization.Users;
using Shopping_Card.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace Shopping_Card.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
