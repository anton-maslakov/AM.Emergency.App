using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IBrigadesRepository
    {
        IEnumerable<BrigadeModel> GetAllData();
        IEnumerable<BrigadeModel> GetBrigadeByDate(DateTime date);
        void Add(BrigadeModel brigadeModel);
        void AddRescuersBrigade(int brigadeNumber, int rescuerId);
        void AddInventoryBrigade(int brigadeNumber, int inventoryNumber);
        //void Edit(int id);
    }
}
