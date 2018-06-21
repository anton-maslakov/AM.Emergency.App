using System;

namespace AM.EmergencyService.App.Common.Helper
{
    public static class ErrorHandlingHelper
    {
        public static void IfArgumentNullException(object obj, string argument)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(argument);
            }
        }
    }
}
