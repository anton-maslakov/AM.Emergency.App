using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models
{
    public class InventoryViewModel
    {
        [Display(Name ="Инвентарный номер")]
        public int InventoryNumber { get; set; }
        [Display(Name = "Инструмент")]
        public string InventoryName { get; set; }
    }
}