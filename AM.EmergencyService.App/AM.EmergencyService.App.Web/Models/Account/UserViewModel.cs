using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Account
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Логин")]
        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        [Required]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        public IEnumerable<int> Roles { get; set; }
    }
}