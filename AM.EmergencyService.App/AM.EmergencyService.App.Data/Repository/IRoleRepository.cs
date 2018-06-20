using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<RoleModel> GetRoleById(int id);
        List<string> GetAllRoles();
    }
}
