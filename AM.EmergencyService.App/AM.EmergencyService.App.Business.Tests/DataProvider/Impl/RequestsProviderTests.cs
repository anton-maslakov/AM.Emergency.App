using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.EmergencyService.App.Business.DataProvider.Impl.Tests
{
    [TestClass()]
    public class RequestsProviderTests
    {
        private Mock<IRequestsRepository> _requestRepository;
        private Mock<ICacheService> _cache;
        private RequestsProvider _requestsProvider;
        private List<RequestModel> _requestList;
        [TestInitialize]
        public void TestInitialize()
        {
            _requestRepository = new Mock<IRequestsRepository>();
            _cache = new Mock<ICacheService>();
            _requestsProvider = new RequestsProvider(_requestRepository.Object, _cache.Object);

            _requestList = new List<RequestModel> {
                new RequestModel {
                    RequestNumber=2,
                    RequestAddress="Город Улица Дом",
                    RequestReason="Причина вызова",
                    Category= new CategoryModel{Id=1, CategoryName="Неотложный"},
                    RequestDate=DateTime.Now.ToString()
                },
                new RequestModel {
                    RequestNumber=8,
                    RequestAddress="Город8 Улица8 Дом8",
                    RequestReason="Причина вызова",
                    Category= new CategoryModel{Id=2, CategoryName="Экстренный"},
                    RequestDate=DateTime.Now.ToString()
                }};
        }

        [TestMethod()]
        public void GetAllData_RequestList()
        {
            _requestRepository.Setup(r=>r.GetAllData()).Returns(_requestList);
            _cache.Setup(c => c.Get<IEnumerable<RequestModel>>(It.IsAny<string>())).Returns<IEnumerable<RequestModel>>(null);
            List<RequestModel> resultList = _requestsProvider.GetAllData().ToList();
            Assert.AreEqual(_requestList[0].RequestNumber, resultList[0].RequestNumber);
            Assert.AreEqual(_requestList[0].RequestAddress, resultList[0].RequestAddress);
            Assert.AreEqual(_requestList[0].RequestDate, resultList[0].RequestDate);
            Assert.AreEqual(_requestList[0].RequestReason, resultList[0].RequestReason);
            _cache.Verify(c => c.Get<IEnumerable<RequestModel>>(It.IsAny<string>()), Times.Once);
            _requestRepository.Verify(r => r.GetAllData(), Times.Once);
        }

        [TestMethod()]
        public void GetRequestByAddress_ValidAddress__RequestList()
        {
            List<RequestModel> returnList;
            _requestRepository.Setup(r => r.GetRequestByAddress(It.IsAny<string>())).Returns(returnList = new List<RequestModel> { _requestList[0] });
            List<RequestModel> resultList = _requestsProvider.GetRequestByAddress("Город Улица Дом", " ").ToList();
            Assert.IsNotNull(resultList);
            Assert.IsTrue(resultList.Count > 0);
            _requestRepository.Verify(r => r.GetRequestByAddress(It.IsAny<string>()), Times.Once);


        }

        [TestMethod()]
        public void GetRequestByCategory_ValidCategory_ListWithRequestCategoryEmergency()
        {
            List<RequestModel> returnList;
            _requestRepository.Setup(r => r.GetRequestByCategory(It.IsAny<string>())).Returns(returnList = new List<RequestModel> { _requestList[1] });
            List<RequestModel> resultList = _requestsProvider.GetRequestByCategory("Неотложный", " ").ToList();
            Assert.AreEqual(8, resultList[0].RequestNumber);
            _requestRepository.Verify(r => r.GetRequestByCategory(It.IsAny<string>()), Times.Once);

        }

        [TestMethod()]
        public void GetRequestByNumber_ValidRequestNumber8_ListWithRequestNumber8()
        {
            List<RequestModel> returnList;
            _requestRepository.Setup(r => r.GetRequestByNumber(It.IsAny<int>())).Returns(returnList = new List<RequestModel> { _requestList[1] });
            List<RequestModel> resultList = _requestsProvider.GetRequestByNumber(8, " ").ToList();
            Assert.AreEqual(returnList[0].RequestNumber, resultList[0].RequestNumber);
            _requestRepository.Verify(r => r.GetRequestByNumber(It.IsAny<int>()), Times.Once);

        }
    }
}