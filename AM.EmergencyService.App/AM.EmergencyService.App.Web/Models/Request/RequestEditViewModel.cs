using System;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Request
{
    public class RequestEditViewModel
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
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequestDate { get; set; }
        [Display(Name = "Категория вызова")]
        [Required]
        public int Category { get; set; }

    }
}