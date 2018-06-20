using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Common.Models
{
    public class IncidentModel
    {
        public int Id { get; set; }
        public string IncidentInformation { get; set; }
        public string IncidentReason { get; set; }
        public int IdRequest { get; set; }
    }
}
