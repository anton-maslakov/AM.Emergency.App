using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Common.Models
{
    public class RequestDetailModel
    {
        public int RequestNumber { get; set; }
        public string IncidentInformation { get; set; }
        public string IncidentReason { get; set; }
        public int BrigadeNumber { get; set; }
        public string BrigadeCallDate { get; set; }
        public string BrigadeArrivalDate { get; set; }
        public string BrigadeEndDate { get; set; }
        public string BrigadeReturnDate { get; set; }
    }
}
