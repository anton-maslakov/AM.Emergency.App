using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Brigade
{
    public class BrigadeCreateViewModel
    {
        [Display(Name = "Номер бригады")]
        [Required]
        public int BrigadeNumber { get; set; }
        [Display(Name = "Члены бригады")]
        [Required]
        public List<int> RescuerId { get; set; }
        [Display(Name = "Инвентарь бригады")]
        [Required]
        public List<int> InventoryNumber { get; set; }
    }
}