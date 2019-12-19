using System.Threading.Tasks;
using Abp.Application.Services;
using Shopping_Card.Authorization.Accounts.Dto;

namespace Shopping_Card.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
