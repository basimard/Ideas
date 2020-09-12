using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Ideas.Controllers
{
    public abstract class IdeasControllerBase: AbpController
    {
        protected IdeasControllerBase()
        {
            LocalizationSourceName = IdeasConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
