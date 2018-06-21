using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRoleProvider
    {
        IEnumerable<RoleModel> GetRoleById(int id);
        IEnumerable<string> GetUserRoles(int id);
        IEnumerable<RoleModel> GetAllRoles();
    }
}
