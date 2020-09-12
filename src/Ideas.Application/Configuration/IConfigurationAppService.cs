using System.Threading.Tasks;
using Ideas.Configuration.Dto;

namespace Ideas.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
