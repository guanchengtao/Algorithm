using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class RedisClientHelper
    {
        private static readonly RedisClient redisClient = null;
        static RedisClientHelper()
        {
            redisClient = new RedisClient("127.0.0.1", 6379);
        }
        public static void AddChche(string key, object value)
        {
            redisClient.Add(key, value);
        }
        public static object GetChche(string key)
        {
             return redisClient.GetValue(key);
        }
        public static void DeleteChche(string key)
        {
            redisClient.Remove(key);
        }
        public static void SetCacheExpires(string key, object value)
        {
            redisClient.Set(key,value);
        }
        public static void SetCacheExpires(string key, object value, DateTime dateTime)
        {
            redisClient.Set(key, value, dateTime);
        }


    }
}
