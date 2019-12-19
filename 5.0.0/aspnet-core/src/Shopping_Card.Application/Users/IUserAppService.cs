using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Shopping_Card.Roles.Dto;
using Shopping_Card.Users.Dto;

namespace Shopping_Card.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
