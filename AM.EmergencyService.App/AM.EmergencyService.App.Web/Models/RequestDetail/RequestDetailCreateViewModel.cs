using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.RequestDetail
{
    public class RequestDetailCreateViewModel
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
        [DataType(DataType.DateTime)]
        public DateTime BrigadeCallDate { get; set; }
        [Display(Name = "Время прибытия бригады")]
        [DataType(DataType.DateTime)]
        public DateTime BrigadeArrivalDate { get; set; }
        [Display(Name = "Время окончания вызова")]
        [DataType(DataType.DateTime)]
        public DateTime BrigadeEndDate { get; set; }
        [Display(Name = "Время возвращения бригады")]
        [DataType(DataType.DateTime)]
        public DateTime BrigadeReturnDate { get; set; }
        [Display(Name = "Пострадавшие")]
        public List<int> CasualtyId { get; set; }
        [Display(Name = "Использованный инвентарь")]
        public List<int> InventoryNumber { get; set; }
    }
}