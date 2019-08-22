using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class RedisClientHelper
    {
        private static RedisClient redisClient = null;
        private static readonly List<Server> ServesList=new List<Server> ();
        static RedisClientHelper()
        {
            string connectionString = ConfigurationManager.AppSettings["RedisCacheServer"];
            string[] Servers = connectionString.Split(',');
            foreach (string item in Servers)
            {
                string[] hostandport = item.Split(':');
                string host = hostandport[0];
                int port = int.Parse(hostandport[1]);
                ServesList.Add(new Server() { Host = host, Port = port });
            }
        }
        public RedisClientHelper(int type)
        {
            if (ServesList != null && ServesList.Count > 0)
            {
                if (type >= 0 && type <= ServesList.Count)
                {
                    var serve = ServesList[type];
                    redisClient = new RedisClient(serve.Host, serve.Port);
                }
            }
        }
        public void AddChche(string key, object value)
        {
            redisClient.Add(key, value.ToString());
        }
        public void AddChcheExpires(string key, object value, DateTime dateTime)
        {
            redisClient.Add(key, value.ToString(), dateTime);
        }
        public object GetChche(string key)
        {
            return redisClient.GetValue(key);
        }
        public void DeleteChche(string key)
        {
            redisClient.Remove(key);
        }
        public void SetCache(string key, object value)
        {
            redisClient.Set(key, value);
        }
        public void SetCacheExpires(string key, object value, DateTime dateTime)
        {
            redisClient.Set(key, value, dateTime);
        }
    }
    class Server
    {
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
