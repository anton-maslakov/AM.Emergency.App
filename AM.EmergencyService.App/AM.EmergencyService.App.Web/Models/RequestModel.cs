using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.App.Web.Models
{
    public class RequestModel : IModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Номер вызова")]
        public int RequestNumber { get; set; }
        [Display(Name = "Адрес вызова")]
        public string RequestAddress { get; set; }
        [Display(Name = "Повод вызова")]
        public string RequestReason { get; set; }
        [Display(Name = "Время вызова")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public string RequestDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время передачи бригаде МЧС")]
        public string BrigadeCallDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время прибытия")]
        public string BrigadeArrivalDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время окончания вызова")]
        public string BrigadeEndDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время возвращения в часть")]
        public string BrigadeReturnDate { get; set; }
        [Display(Name = "Категория вызова")]
        public string RequestCategory { get; set; }
    }
}