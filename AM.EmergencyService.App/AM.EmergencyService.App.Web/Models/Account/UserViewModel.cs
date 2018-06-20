using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Account
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}