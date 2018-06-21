using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Inventory
{
    public class InventoryViewModel
    {
        [Display(Name ="Инвентарный номер")]
        [Required]
        public int InventoryNumber { get; set; }
        [Display(Name = "Инструмент")]
        [Required]
        public string InventoryName { get; set; }
    }
}