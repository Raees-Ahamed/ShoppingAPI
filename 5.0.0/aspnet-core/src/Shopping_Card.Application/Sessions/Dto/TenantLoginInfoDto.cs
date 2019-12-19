using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Shopping_Card.MultiTenancy;

namespace Shopping_Card.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
