using System.Threading.Tasks;
using Shiv.MyProject.Configuration.Dto;

namespace Shiv.MyProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
