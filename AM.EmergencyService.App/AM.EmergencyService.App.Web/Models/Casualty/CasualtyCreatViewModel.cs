using System;
using System.ComponentModel.DataAnnotations;

namespace AM.EmergencyService.App.Web.Models.Casualty
{
    public class CasualtyCreatViewModel
    {
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Firstname { get; set; }
        [Display(Name = "Отчество")]
        public string Lastname { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Адрес прописки")]
        public string Address { get; set; }

    }
}