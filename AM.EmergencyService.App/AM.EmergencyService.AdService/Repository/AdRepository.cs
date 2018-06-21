using AM.EmergencyService.AdService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AM.EmergencyService.AdService.Repository
{
    public class AdRepository
    {
        IList<AdvertisingModel> _listOfAd;

        public IList<AdvertisingModel> List { get { return _listOfAd; } }

        public AdRepository()
        {
            _listOfAd = new List<AdvertisingModel> {
                new AdvertisingModel{ Id=1,Header="Samsung",AdText="Смартофны Samsung. Turn On Tomorrow"},
                new AdvertisingModel{ Id=2,Header="Apple",AdText="Смартофны Apple. Think Different"},
                new AdvertisingModel{ Id=3,Header="Lenovo",AdText="Смартофны Lenovo. For those who do"},
                new AdvertisingModel{ Id=4,Header="Meizu",AdText="Смартофны Meizu. Think Higher"},
                new AdvertisingModel{ Id=5,Header="LG",AdText="Смартофны LG. Life's Good"},
                new AdvertisingModel{ Id=6,Header="ASUS",AdText="Смартофны ASUS. IN SEARCH OF INCREDIBLE"},
                new AdvertisingModel{ Id=7,Header="Huawei",AdText="Смартофны Huawei. MAKE IT POSSIBLE"},
                new AdvertisingModel{ Id=8,Header="HTC",AdText="Смартофны HTC. quietly brilliant"},
                new AdvertisingModel{ Id=9,Header="Xiaomi",AdText="Смартофны Xiaomi. Innovation for Everyone"},
                new AdvertisingModel{ Id=10,Header="Sony",AdText="Смартофны Sony. make.believe"}
            };
        }

        public IEnumerable<AdvertisingModel> GetAdvertising(int numberOfAd)
        {
            if (numberOfAd > _listOfAd.Count)
            {
                throw new IndexOutOfRangeException("Number of requested items is more than items in list!");
            }

            if (numberOfAd == _listOfAd.Count)
            {
                return _listOfAd;
            }

            List<AdvertisingModel> listOfAd = new List<AdvertisingModel>();

            Random rnd = new Random();

            int[] arrayOfRandomNumbers = new int[numberOfAd];

            for (int i = 0, randomNum = 0; i < numberOfAd; i++)
            {
                do
                {
                    randomNum = rnd.Next(1, _listOfAd.Count);
                } while (arrayOfRandomNumbers.Contains(randomNum));
                arrayOfRandomNumbers[i] = randomNum;
                listOfAd.Add(_listOfAd[randomNum]);
            }
            return listOfAd;
        }
    }
}