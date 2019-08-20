using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisClientHelper.AddChche("1", "aaa");
            object msg = RedisClientHelper.GetChche("1");
            Console.WriteLine(msg);
            RedisClientHelper.SetCacheExpires("1",DateTime.Now.AddSeconds(10));
            Console.Read();
        }
    }
}
