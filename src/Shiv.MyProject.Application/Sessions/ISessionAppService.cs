using System.Threading.Tasks;
using Abp.Application.Services;
using Shiv.MyProject.Sessions.Dto;

namespace Shiv.MyProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
