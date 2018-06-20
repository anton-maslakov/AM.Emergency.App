using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using System;
using System.Runtime.Caching;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class СacheService : ICacheService
    {
        private ILogger _logger;

        private MemoryCache _cache;
        public СacheService(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _cache = MemoryCache.Default;
            _logger = logger;
        }
        public bool Add<T>(string key, T value, int seconds)
        {
            return _cache.Add(key, value, DateTime.Now.AddSeconds(seconds));
        }

        public void Delete(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }

        public T Get<T>(string key) where T : class
        {
            return _cache.Get(key) as T;
        }

        public void Update<T>(string key, T value, int seconds)
        {
            _cache.Set(key, value, DateTime.Now.AddSeconds(seconds));
        }
    }
}
