using System.Threading.Tasks;
using Shopping_Card.Configuration.Dto;

namespace Shopping_Card.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
