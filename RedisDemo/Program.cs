using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            //  RedisClientHelper redisClient = new RedisClientHelper(0);
            //  redisClient.AddChche("2", "World");
            //  RedisClientHelper redisClient1 = new RedisClientHelper(1);
            //   Console.WriteLine(redisClient1.GetChche("2"));
            //从节点只能读
            //redisClient1.AddChche("2", "World");
            // Console.WriteLine(msg1);
            //   RedisClientHelper.SetCacheExpires("1",DateTime.Now.AddSeconds(10));


            RedisClientHelper redisClient = new RedisClientHelper(0);
            //Person p = new Person()
            //{
            //    Id = 1,
            //    Age = 20,
            //    Name = "Mr.G",
            //    Nation = "China"
            //};
            //string jsonp = DeserializeHelper.WriteFromObject(p);
            //redisClient.AddChche("P1", jsonp);
            //string jsonp = redisClient.GetChche("P1").ToString();

            //var newp = DeserializeHelper.DeserializeObject<Person>(jsonp);
            //Console.WriteLine(newp.Id + "-" + newp.Name + "-" + newp.Age + "-" + newp.Nation);

            //List<Person> list = new List<Person>()
            //{
            //    new Person(){Id = 1, Name = "Mr.S"},
            //    new Person(){Id = 2, Name = "Mr.W"},
            //    new Person(){Id = 3, Name = "Mr.H"},
            //};
            //string msg = DeserializeHelper.SerializeObject(list);
            //redisClient.AddChche("P2", msg);
            //string value = redisClient.GetChche("P2").ToString();
            //var PersonList = DeserializeHelper.DeserializeObject<List<Person>>(value);
            //PersonList.ForEach(x =>
            //{
            //    Console.WriteLine(x.Id + ","+x.Name+","+x.Nation);
            //});
            //int[] nums = { 1, 2, 3, 4, 5, 6 };
            //redisClient.AddChche("Array", DeserializeHelper.SerializeObject(nums));
            //var res = DeserializeHelper.DeserializeObject<Array>(redisClient.GetChche("Array").ToString());
            //foreach (var item in res)
            //{
            //   Console.WriteLine(item);
            //}
            // DeserializeHelper.SerializeObjectToXml(list);
            //string path = "d:\\serialize.xml";
            //var p = (Person)DeserializeHelper.DeserializeXmlToObject<Person>(path) ;
            //Console.WriteLine(p.Id+ "-" +p.Name);
            //   TextFormatter.TextToXml("d:\\origin.txt");
            Person p = new Person();
            Console.WriteLine(p.GetType().GetProperties().Length);
            Console.WriteLine("ok");
            Console.Read();
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string Nation { get; set; }
    }
    public static class TextFormatter
    {
        public static bool TextToXml(string Topath)
        {
            //先拿到文本,格式：Id:1|Name:Mr.G|Age:20|Nation|China
            string[] personStringList = File.ReadAllLines(@Topath);
            List<Person> personList = new List<Person>();
            
            foreach (var item in personStringList)
            {
                string[] person = item.Split('|'); //count == 6
                Person p = new Person()
                {
                    Id = int.Parse(person[0].Split(':')[1]),
                    Name = person[1].Split(':')[1],
                    Age = int.Parse(person[2].Split(':')[1]),
                    Nation = person[3].Split(':')[1],
                };
                personList.Add(p);
            }
            DeserializeHelper.SerializeObjectToXml(personList, "d:\\result.xml");
            return true;
        }
    }
}