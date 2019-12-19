using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_Card.Authorization;

namespace Shopping_Card
{
    [DependsOn(
        typeof(Shopping_CardCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Shopping_CardApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Shopping_CardAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Shopping_CardApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
