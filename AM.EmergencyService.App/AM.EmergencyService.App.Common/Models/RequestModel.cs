using System;

namespace AM.EmergencyService.App.Common.Models
{
    public class RequestModel
    {
        public int RequestNumber { get; set; }
        public string RequestAddress { get; set; }
        public string RequestReason { get; set; }
        public DateTime RequestDate { get; set; }
        public CategoryModel Category { get; set; }
    }
}