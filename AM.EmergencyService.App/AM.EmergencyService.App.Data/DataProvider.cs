using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data
{
    public class DataProvider : IDataProvider
    {
        public ICollection<BrigadeModel> Brigades
        {
            get
            {
                return new List<BrigadeModel>()
            {
               new BrigadeModel() { Id = 1, BrigadeNumber=1},
               new BrigadeModel() { Id = 2, BrigadeNumber=2},
               new BrigadeModel() { Id = 3, BrigadeNumber=3},
               new BrigadeModel() { Id = 4, BrigadeNumber=4},
            };
            }
        }

        public ICollection<RequestModel> Requests
        {
            get
            {
                return new List<RequestModel>()
            {
               new RequestModel() { Id = 1, RequestNumber = 1, RequestAddress = "г.Могилев, ул. Ленинская, д. 26, кв. 76", RequestReason = "Пожар", RequestDate=DateTime.Parse("25.04.2018 15:03"), BrigadeCallDate=DateTime.Parse("25.04.2018 15:03"), BrigadeArrivalDate=DateTime.Parse("25.04.2018 15:19"), BrigadeEndDate=DateTime.Parse("25.04.2018 16:48"), BrigadeReturnDate=DateTime.Parse("25.04.2018 17:30"), RequestCategory="Неотложный"},
               new RequestModel() { Id = 2, RequestNumber = 2, RequestAddress = "г.Могилев, перекрёсток ул. Островского и б-ра. Непокоренных", RequestReason = "ДТП", RequestDate=DateTime.Parse("25.04.2018 16:31"), BrigadeCallDate=DateTime.Parse("25.04.2018 16:31"), BrigadeArrivalDate=DateTime.Parse("25.04.2018 16:39"), BrigadeEndDate=DateTime.Parse("25.04.2018 17:21"), BrigadeReturnDate=DateTime.Parse("25.04.2018 17:56"), RequestCategory="Срочный"},
               new RequestModel() { Id = 3, RequestNumber = 3, RequestAddress = "г.Могилев, б-р. Первомайская, д. 94", RequestReason = "Взрыв", RequestDate=DateTime.Parse("25.04.2018 23:48"), BrigadeCallDate=DateTime.Parse("25.04.2018 23:49"), BrigadeArrivalDate=DateTime.Parse("26.04.2018 00:09"), BrigadeEndDate=DateTime.Parse("26.04.2018 03:48"), BrigadeReturnDate=DateTime.Parse("26.04.2018 04:15"), RequestCategory="Экстренный"},
               new RequestModel() { Id = 4, RequestNumber = 4, RequestAddress = "г.Могилев, ул. Гагарина, д. 58", RequestReason = "Котик застрял на дереве", RequestDate=DateTime.Parse("26.04.2018 15:03"), BrigadeCallDate=DateTime.Parse("26.04.2018 15:03"), BrigadeArrivalDate=DateTime.Parse("26.04.2018 15:19"), BrigadeEndDate=DateTime.Parse("26.04.2018 16:48"), BrigadeReturnDate=DateTime.Parse("26.04.2018 17:30"), RequestCategory="Экстренный"},
            };
            }
        }

        public ICollection<RescuerModel> Rescuers
        {
            get
            {
                return new List<RescuerModel>()
            {
               new RescuerModel() { Id = 1, Name="Имя 1", LastName="Отчество 1", Surname="Фамилия 1", BrigadeNumber=1},
               new RescuerModel() { Id = 2, Name="Имя 2", LastName="Отчество 2", Surname="Фамилия 2", BrigadeNumber=2},
               new RescuerModel() { Id = 3, Name="Имя 3", LastName="Отчество 3", Surname="Фамилия 3", BrigadeNumber=1},
               new RescuerModel() { Id = 4, Name="Имя 4", LastName="Отчество 4", Surname="Фамилия 4", BrigadeNumber=1},
               new RescuerModel() { Id = 5, Name="Имя 5", LastName="Отчество 5", Surname="Фамилия 5", BrigadeNumber=1},
               new RescuerModel() { Id = 6, Name="Имя 6", LastName="Отчество 6", Surname="Фамилия 6", BrigadeNumber=4},
               new RescuerModel() { Id = 7, Name="Имя 7", LastName="Отчество 7", Surname="Фамилия 7", BrigadeNumber=3},
               new RescuerModel() { Id = 8, Name="Имя 8", LastName="Отчество 8", Surname="Фамилия 8", BrigadeNumber=3},
               new RescuerModel() { Id = 9, Name="Имя 9", LastName="Отчество 9", Surname="Фамилия 9", BrigadeNumber=2},
               new RescuerModel() { Id = 10, Name="Имя 10", LastName="Отчество 10", Surname="Фамилия 10", BrigadeNumber=2},
               new RescuerModel() { Id = 11, Name="Имя 11", LastName="Отчество 11", Surname="Фамилия 11", BrigadeNumber=2},
               new RescuerModel() { Id = 12, Name="Имя 12", LastName="Отчество 12", Surname="Фамилия 12", BrigadeNumber=3},
               new RescuerModel() { Id = 13, Name="Имя 13", LastName="Отчество 13", Surname="Фамилия 13", BrigadeNumber=4},
            };
            }
        }
    }
}
