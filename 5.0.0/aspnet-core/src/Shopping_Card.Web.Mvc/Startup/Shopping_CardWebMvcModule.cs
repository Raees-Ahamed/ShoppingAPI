using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_Card.Configuration;
using Abp.AutoMapper;

namespace Shopping_Card.Web.Startup
{
    [DependsOn(typeof(Shopping_CardWebCoreModule))]
    public class Shopping_CardWebMvcModule : AbpModule
    {
        [System.Obsolete]
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        [System.Obsolete]
        public Shopping_CardWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<Shopping_CardNavigationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Shopping_CardWebMvcModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
