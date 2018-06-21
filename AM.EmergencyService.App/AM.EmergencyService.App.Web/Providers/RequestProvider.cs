using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.EmergencyService.App.Web.Models;

namespace AM.EmergencyService.App.Web.Providers
{
    public class RequestProvider : IDataProvider
    {
        public IEnumerable<IModel> GetData()
        {
            var requestData = new List<RequestModel>()
            {
               new RequestModel() { Id = 1, RequestNumber = 1, RequestAddress = "г.Могилев, ул. Ленинская, д. 26, кв. 76", RequestReason = "Пожар", RequestDate="25.04.2018 15:03", BrigadeCallDate="25.04.2018 15:03", BrigadeArrivalDate="25.04.2018 15:19", BrigadeEndDate="25.04.2018 16:48", BrigadeReturnDate="25.04.2018 17:30", RequestCategory="Неотложный"},
               new RequestModel() { Id = 2, RequestNumber = 2, RequestAddress = "г.Могилев, перекрёсток ул. Островского и б-ра. Непокоренных", RequestReason = "ДТП", RequestDate="25.04.2018 16:31", BrigadeCallDate="25.04.2018 16:31", BrigadeArrivalDate="25.04.2018 16:39", BrigadeEndDate="25.04.2018 17:21", BrigadeReturnDate="25.04.2018 17:56", RequestCategory="Срочный"},
               new RequestModel() { Id = 3, RequestNumber = 3, RequestAddress = "г.Могилев, б-р. Первомайская, д. 94", RequestReason = "Взрыв", RequestDate="25.04.2018 23:48", BrigadeCallDate="25.04.2018 23:49", BrigadeArrivalDate="26.04.2018 00:09", BrigadeEndDate="26.04.2018 03:48", BrigadeReturnDate="26.04.2018 04:15", RequestCategory="Экстренный"},
               new RequestModel() { Id = 4, RequestNumber = 4, RequestAddress = "г.Могилев, ул. Гагарина, д. 58", RequestReason = "Котик застрял на дереве", RequestDate="26.04.2018 15:03", BrigadeCallDate="26.04.2018 15:03", BrigadeArrivalDate="26.04.2018 15:19", BrigadeEndDate="26.04.2018 16:48", BrigadeReturnDate="26.04.2018 17:30", RequestCategory="Экстренный"},
            };

            return requestData;
        }
    }
}
