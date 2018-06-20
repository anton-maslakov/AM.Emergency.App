using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Casualty
{
    public class CasualtyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Пострадавшие")]
        public string Name { get; set; }

    }
}