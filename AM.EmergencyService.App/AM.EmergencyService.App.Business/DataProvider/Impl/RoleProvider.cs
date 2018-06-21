using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RoleProvider : IRoleProvider
    {
        ILogger _logger;
        IRoleRepository _repos;
        public RoleProvider(ILogger logger, IRoleRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRoleRepository");
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<RoleModel> GetAllRoles()
        {
            return _repos.GetAllRoles();
        }

        public IEnumerable<RoleModel> GetRoleById(int id)
        {
            return _repos.GetRoleById(id);
        }

        public IEnumerable<string> GetUserRoles(int id)
        {
            return _repos.GetUserRoles(id);
        }
    }
}
