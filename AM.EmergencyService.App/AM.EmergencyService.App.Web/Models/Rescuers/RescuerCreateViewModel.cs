using System;

namespace AM.EmergencyService.App.Web.Models.Rescuers
{
    public class RescuerCreateViewModel
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }
    }
}