using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Shopping_Card.MultiTenancy.Dto;

namespace Shopping_Card.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

