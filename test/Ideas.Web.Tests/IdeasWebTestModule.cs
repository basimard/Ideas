using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Ideas.EntityFrameworkCore;
using Ideas.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Ideas.Web.Tests
{
    [DependsOn(
        typeof(IdeasWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IdeasWebTestModule : AbpModule
    {
        public IdeasWebTestModule(IdeasEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdeasWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IdeasWebMvcModule).Assembly);
        }
    }
}