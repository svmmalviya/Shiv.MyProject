using Abp.Application.Services;
using Shiv.MyProject.MultiTenancy.Dto;

namespace Shiv.MyProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

