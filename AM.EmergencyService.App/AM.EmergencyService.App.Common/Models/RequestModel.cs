using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.App.Common.Models
{
    public class RequestModel
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
        public DateTime RequestDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время передачи бригаде МЧС")]
        public DateTime BrigadeCallDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время прибытия")]
        public DateTime BrigadeArrivalDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время окончания вызова")]
        public DateTime BrigadeEndDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Время возвращения в часть")]
        public DateTime BrigadeReturnDate { get; set; }
        [Display(Name = "Категория вызова")]
        public string RequestCategory { get; set; }
        public int idBrigade { get; set; }
    }
}