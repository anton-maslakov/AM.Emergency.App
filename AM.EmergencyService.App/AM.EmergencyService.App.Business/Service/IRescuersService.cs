namespace AM.EmergencyService.App.Business.Service
{
    public interface IRescuersService
    {
        void DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId);

    }
}
