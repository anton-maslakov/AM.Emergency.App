using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Brigade
{
    public class BrigadeCreateViewModel
    {
        [Display(Name = "Номер бригады")]
        public int BrigadeNumber { get; set; }
        [Display(Name = "Члены бригады")]
        public List<int> RescuerId { get; set; }
        [Display(Name = "Инвентарь бригады")]
        public List<int> InventoryNumber { get; set; }
    }
}