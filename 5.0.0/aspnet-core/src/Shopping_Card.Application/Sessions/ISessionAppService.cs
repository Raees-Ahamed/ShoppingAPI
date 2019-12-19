using System.Threading.Tasks;
using Abp.Application.Services;
using Shopping_Card.Sessions.Dto;

namespace Shopping_Card.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
