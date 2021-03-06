﻿using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRescuersProvider
    {
        IEnumerable<RescuerModel> GetAllData();
        IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber, DateTime date);
        RescuerModel GetRescuerById(int rescuerId);
    }
}
