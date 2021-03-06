﻿using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IInventoryProvider
    {
        IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber);
        IEnumerable<InventoryModel> GetInventoryNotInRequest(int requestNumber);
        IEnumerable<InventoryModel> GetInventoryByBrigadeNumber(int brigadeNumber, DateTime date);
        IEnumerable<InventoryModel> GetAllData();
        InventoryModel GetInventoryByNumber(int inventoryNumber);
    }
}
