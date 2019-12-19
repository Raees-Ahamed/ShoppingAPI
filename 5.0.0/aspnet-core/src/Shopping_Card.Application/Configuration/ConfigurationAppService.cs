using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Shopping_Card.Configuration.Dto;

namespace Shopping_Card.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Shopping_CardAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
