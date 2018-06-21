using System;

namespace AM.EmergencyService.App.Common.Models
{
    public class RescuerModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }
    }
}