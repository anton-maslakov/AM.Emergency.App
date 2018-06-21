using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Request
{
    public class RequestViewModel
    {
        [Display(Name = "Номер вызова")]
        [Required]
        public int RequestNumber { get; set; }
        [Display(Name = "Адрес вызова")]
        [Required]
        public string RequestAddress { get; set; }
        [Display(Name = "Причина вызова")]
        [Required]
        public string RequestReason { get; set; }
        [Display(Name = "Дата вызова")]
        [DataType(DataType.DateTime)]
        [Required]
        public string RequestDate { get; set; }
        [Display(Name = "Категория вызова")]
        [Required]
        public string CategoryName { get; set; }
    }
}