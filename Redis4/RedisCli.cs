using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace Redis
{
    public static class RedisCliDb
    {
        
        private static string _host = "localhost";
        private static int _port = 6378;

        public static string GET(string key)
        {
            using (RedisClient cli = new RedisClient(_host, _port))
                return cli.Get<string>(key);
        }

        public static bool SET(string key, string value)
        {
            try
            {
                using (RedisClient cli = new RedisClient(_host, _port))
                    cli.Set(key, value, TimeSpan.FromSeconds(10));

                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
