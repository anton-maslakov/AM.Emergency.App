using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Request
{
    public class RequestCreateViewModel
    {
        [Display(Name = "Адрес вызова")]
        [Required]
        public string RequestAddress { get; set; }
        [Display(Name = "Причина вызова")]
        [Required]
        public string RequestReason { get; set; }
        [Display(Name = "Категория вызова")]
        [Required]
        public int CategoryId { get; set; }
    }
}