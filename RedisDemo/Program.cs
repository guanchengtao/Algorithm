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
            List<Person> list = new List<Person>()
            {
                new Person(){Id=3},
            };
            if(!list.Any(x=>x.Id == 1))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
           

        //  RedisClientHelper redisClient = new RedisClientHelper(0);
        //  redisClient.AddChche("2", "World");
        //  RedisClientHelper redisClient1 = new RedisClientHelper(1);
        //   Console.WriteLine(redisClient1.GetChche("2"));
        //从节点只能读
        //redisClient1.AddChche("2", "World");
        // Console.WriteLine(msg1);
        //   RedisClientHelper.SetCacheExpires("1",DateTime.Now.AddSeconds(10));
            Console.Read();
        }
    }
    class Person
    {
        public int Id { get; set; }
    }
}