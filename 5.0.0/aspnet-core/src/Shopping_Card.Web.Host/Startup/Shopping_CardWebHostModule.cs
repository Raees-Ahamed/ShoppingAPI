using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_Card.Configuration;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.Reflection;

namespace Shopping_Card.Web.Host.Startup
{
    [DependsOn(
       typeof(Shopping_CardWebCoreModule))]
    public class Shopping_CardWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        

        public Shopping_CardWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void Initialize()
        {
            var thisAssembly = typeof(Shopping_CardWebHostModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
