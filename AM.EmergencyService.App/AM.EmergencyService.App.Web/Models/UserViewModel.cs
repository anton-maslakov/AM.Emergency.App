using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}