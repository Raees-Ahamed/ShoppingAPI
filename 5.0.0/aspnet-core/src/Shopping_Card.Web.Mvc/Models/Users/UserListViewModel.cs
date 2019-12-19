using System.Collections.Generic;
using Shopping_Card.Roles.Dto;
using Shopping_Card.Users.Dto;

namespace Shopping_Card.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
