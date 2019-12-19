using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Shopping_Card.Authorization.Roles;
using Shopping_Card.Authorization.Users;
using Shopping_Card.Configuration;
using Shopping_Card.Localization;
using Shopping_Card.MultiTenancy;
using Shopping_Card.Timing;

namespace Shopping_Card
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class Shopping_CardCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            Shopping_CardLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = Shopping_CardConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Shopping_CardCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
