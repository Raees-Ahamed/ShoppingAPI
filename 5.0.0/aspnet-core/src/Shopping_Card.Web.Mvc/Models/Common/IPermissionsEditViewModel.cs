using System.Collections.Generic;
using Shopping_Card.Roles.Dto;

namespace Shopping_Card.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}