using System;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Casualty
{
    public class CasualtyViewModel
    {
        public int Id { get; set; }
        [Display(Name="Фамилия")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string Firstname { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        public string Lastname { get; set; }
        [Display(Name = "Дата рождения")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Адрес прописки")]
        [Required]
        public string Address { get; set; }

    }
}