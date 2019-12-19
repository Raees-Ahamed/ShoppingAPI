using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Shopping_Card.Configuration;
using Shopping_Card.EntityFrameworkCore;
using Shopping_Card.Migrator.DependencyInjection;

namespace Shopping_Card.Migrator
{
    [DependsOn(typeof(Shopping_CardEntityFrameworkModule))]
    public class Shopping_CardMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Shopping_CardMigratorModule(Shopping_CardEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(Shopping_CardMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                Shopping_CardConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Shopping_CardMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
