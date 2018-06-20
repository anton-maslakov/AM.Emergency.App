namespace AM.EmergencyService.App.Web.Models
{
    public class RequestViewModel
    {
        public int RequestNumber { get; set; }
        public string RequestAddress { get; set; }
        public string RequestReason { get; set; }
        public string RequestDate { get; set; }
        public string CategoryName { get; set; }
    }
}