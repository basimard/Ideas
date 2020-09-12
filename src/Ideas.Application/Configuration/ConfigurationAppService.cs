using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Ideas.Configuration.Dto;

namespace Ideas.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IdeasAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
