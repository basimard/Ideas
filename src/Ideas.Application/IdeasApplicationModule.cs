using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ideas.Authorization;

namespace Ideas
{
    [DependsOn(
        typeof(IdeasCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdeasApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<IdeasAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdeasApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
