using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Rescuers
{
    public class RescuerSelectViewModel
    {
        public int Id { get; set; }
        [Display(Name="Члены бригады")]
        public string Name { get; set; }
    }
}