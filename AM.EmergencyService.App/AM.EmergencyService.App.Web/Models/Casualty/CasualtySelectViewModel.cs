using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Casualty
{
    public class CasualtySelectViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Пострадавшие")]
        [Required]
        public string Name { get; set; }

    }
}