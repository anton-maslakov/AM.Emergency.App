using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.App.Common.Models
{
    public class RescuerModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BirthDate { get; set; }
        public string Job { get; set; }
    }
}