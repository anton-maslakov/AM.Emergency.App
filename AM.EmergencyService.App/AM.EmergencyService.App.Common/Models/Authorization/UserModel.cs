using System.Collections.Generic;

namespace AM.EmergencyService.App.Common.Models.Authorization
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public IEnumerable<RoleModel> Roles { get; set; }
        public string Email { get; set; }
    }
}
