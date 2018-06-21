using System;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Brigade
{
    public class BrigadeViewModel
    {
        [Display(Name = "Номер бригады")]
        [Required]
        public int BrigadeNumber { get; set; }
        [Display(Name = "Дата")]
        [Required]
        public DateTime Date { get; set; }
    }
}