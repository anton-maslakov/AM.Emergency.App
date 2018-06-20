using AM.EmergencyService.App.Common.Models.Authorization;
using System.Linq;
using System.Security.Principal;

namespace AM.EmergencyService.App.Business.Model
{
    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public UserModel User { get; set; }
        public UserPrincipal(UserModel user)
        {
            User = user;
            Identity = new GenericIdentity(user.Name);
        }

        public bool IsInRole(string role)
        {
            return User.Roles.Select(r => r.Rolename).Contains(role);
        }
    }
}
