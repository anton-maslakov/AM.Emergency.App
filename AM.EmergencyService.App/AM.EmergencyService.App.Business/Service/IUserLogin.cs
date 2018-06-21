namespace AM.EmergencyService.App.Business.Service
{
    public interface IUserLogin
    {
        void LogIn(string login, string password);
        void LogOut();
    }
}
