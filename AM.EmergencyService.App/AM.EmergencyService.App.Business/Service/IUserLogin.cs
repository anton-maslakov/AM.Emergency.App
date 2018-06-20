using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IUserLogin
    {
        void LogIn(string login, string password);
        void LogOut();
    }
}
