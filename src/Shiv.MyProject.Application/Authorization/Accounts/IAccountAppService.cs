using System.Threading.Tasks;
using Abp.Application.Services;
using Shiv.MyProject.Authorization.Accounts.Dto;

namespace Shiv.MyProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
