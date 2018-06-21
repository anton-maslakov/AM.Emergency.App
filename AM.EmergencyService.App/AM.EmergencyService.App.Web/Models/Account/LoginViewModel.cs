using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}