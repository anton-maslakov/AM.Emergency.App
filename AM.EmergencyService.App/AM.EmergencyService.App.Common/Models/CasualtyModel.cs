using System;

namespace AM.EmergencyService.App.Common.Models
{
    public class CasualtyModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
