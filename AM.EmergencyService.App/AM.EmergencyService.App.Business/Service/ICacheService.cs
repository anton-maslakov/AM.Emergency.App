namespace AM.EmergencyService.App.Business.Service
{
    public interface ICacheService
    {
        T Get<T>(string key) where T : class;
        bool Add<T>(string key, T value, int seconds);
        void Update<T>(string key, T value, int seconds);
        void Delete(string key);
    }
}
