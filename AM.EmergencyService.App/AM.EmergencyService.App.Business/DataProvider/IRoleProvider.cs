using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRoleProvider
    {
        IEnumerable<RoleModel> GetRoleById(int id);
        List<string> GetAllRoles();
    }
}
