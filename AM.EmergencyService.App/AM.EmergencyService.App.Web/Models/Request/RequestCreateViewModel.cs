using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Request
{
    public class RequestCreateViewModel
    {
        [Display(Name = "Адрес вызова")]
        public string RequestAddress { get; set; }
        [Display(Name = "Причина вызова")]
        public string RequestReason { get; set; }
        [Display(Name = "Категория вызова")]
        public int CategoryId { get; set; }
    }
}