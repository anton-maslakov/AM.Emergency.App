using System;

namespace AM.EmergencyService.App.Common.Models
{
    public class RequestDetailModel
    {
        public int RequestNumber { get; set; }
        public string IncidentInformation { get; set; }
        public string IncidentReason { get; set; }
        public int BrigadeNumber { get; set; }
        public DateTime BrigadeCallDate { get; set; }
        public DateTime BrigadeArrivalDate { get; set; }
        public DateTime BrigadeEndDate { get; set; }
        public DateTime BrigadeReturnDate { get; set; }
    }
}
