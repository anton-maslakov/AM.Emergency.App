﻿namespace AM.EmergencyService.App.Common.Models
{
    public class RequestModel
    {
        public int RequestNumber { get; set; }
        public string RequestAddress { get; set; }
        public string RequestReason { get; set; }
        public string RequestDate { get; set; }
        public CategoryModel Category { get; set; }
    }
}