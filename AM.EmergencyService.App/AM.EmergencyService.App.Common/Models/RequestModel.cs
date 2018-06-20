using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.App.Common.Models
{
    public class RequestModel
    {
        public int RequestNumber { get; set; }
        public string RequestAddress { get; set; }
        public string RequestReason { get; set; }
        public string RequestDate { get; set; }
        public string CategoryName { get; set; }
    }
}