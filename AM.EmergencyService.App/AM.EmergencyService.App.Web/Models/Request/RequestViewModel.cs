using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Request
{
    public class RequestViewModel
    {
        [Display(Name = "Номер вызова")]
        public int RequestNumber { get; set; }
        [Display(Name = "Адрес вызова")]
        public string RequestAddress { get; set; }
        [Display(Name = "Причина вызова")]
        public string RequestReason { get; set; }
        [Display(Name = "Дата вызова")]
        [DataType(DataType.DateTime)]
        public string RequestDate { get; set; }
        [Display(Name = "Категория вызова")]
        public string CategoryName { get; set; }
    }
}