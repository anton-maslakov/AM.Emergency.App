using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IBrigadeService
    {
        void Add(BrigadeModel brigadeModel);
        void AddRescuersBrigade(int brigadeNumber, int rescuerId);
        void AddInventoryBrigade(int brigadeNumber, int inventoryNumber);

    }
}