using System;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.RequestDetail
{
    public class RequestDetailViewModel
    {
        [Display(Name = "Номер вызова")]
        [Required]
        public int RequestNumber { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Информация о вызове")]
        public string IncidentInformation { get; set; }
        [Display(Name = "Причина происшествия")]
        [DataType(DataType.MultilineText)]
        public string IncidentReason { get; set; }
        [Display(Name = "Номер бригады")]
        public int BrigadeNumber { get; set; }
        [Display(Name = "Время вызова бригады")]
        public DateTime BrigadeCallDate { get; set; }
        [Display(Name = "Время прибытия бригады")]
        public DateTime BrigadeArrivalDate { get; set; }
        [Display(Name = "Время окончания вызова")]
        public DateTime BrigadeEndDate { get; set; }
        [Display(Name = "Время возвращения бригады")]
        public DateTime BrigadeReturnDate { get; set; }
    }
}