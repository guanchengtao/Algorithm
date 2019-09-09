using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
              RedisClientHelper redisClient = new RedisClientHelper(0);
            //  redisClient.AddChche("2", "World");
            //  RedisClientHelper redisClient1 = new RedisClientHelper(1);
            //   Console.WriteLine(redisClient1.GetChche("2"));
            //从节点只能读
            //redisClient1.AddChche("2", "World");
            // Console.WriteLine(msg1);
            //   RedisClientHelper.SetCacheExpires("1",DateTime.Now.AddSeconds(10));


            //RedisClientHelper redisClient = new RedisClientHelper(0);
            //redisClient.AddChcheExpires("Test", "TestValue", DateTime.Now.AddMinutes(1));
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
            //Console.WriteLine(newp.Id + "," + newp.Name + "," + newp.Age + "," + newp.Nation);

            #region  序列化与反序列化
            
            List<Person> list = new List<Person>()
            {
                new Person(){Id = 1, Name = "Mr.S"},
                new Person(){Id = 2, Name = "Mr.W"},
                new Person(){Id = 3, Name = "Mr.H"},
            };
            string msg = DeserializeHelper.SerializeObject(list);
            redisClient.AddChche("P3", msg);
            //string value = redisClient.GetChche("P2").ToString();
            //var PersonList = DeserializeHelper.DeserializeObject<List<Person>>(value);
            //PersonList.ForEach(x =>
            //{
            //    Console.WriteLine(x.Id + "," + x.Name + "," + x.Nation);
            //});
            //int[] nums = { 1, 2, 3, 4, 5, 6 };
            //redisClient.AddChche("Array", DeserializeHelper.SerializeObject(nums));
            //var res = DeserializeHelper.DeserializeObject<Array>(redisClient.GetChche("Array").ToString());
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}
            //DeserializeHelper.SerializeObjectToXml(list,"");
            //string path = "d:\\serialize.xml";
            //var p = (Person)DeserializeHelper.DeserializeXmlToObject<Person>(path);
            //Console.WriteLine(p.Id + "-" + p.Name);
            //TextFormatter.TextToXml("d:\\origin.txt"); 
            
            #endregion

            //double num1 = 15;
            //double num2 = 23;
            //Console.WriteLine(Math.Ceiling(num2/num1));
            ////向上取整
            //List<Person> list = new List<Person>()
            //{
            //    new Person(){Id = 1, Name = "Mr.S",Age = 20},
            //    new Person(){Id = 2, Name = "Mr.W",Age = 21},
            //    new Person(){Id = 3, Name = "Mr.H",Age = 22},
            //    new Person(){Id = 4, Name = "Mr.G",Age = 23}
            //};
            //var ids = list.Select(x => x.Id).ToList();
            //ids.ForEach(x =>
            //{
            //    Console.WriteLine(x);
            //});
            //var abc = "123";
            //var isNumber = abc.IsNumber();
            //Console.WriteLine(isNumber);
            Console.Read();
        }
    }

    public static class StringExt
    {
        static private Regex regexNumber = new Regex("\\d+");
        static public bool IsNumber(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return regexNumber.IsMatch(input);
        }
        static public void WriteLine(this int input)
        {
            Console.WriteLine(input);
        }
        static public void Print(this int input,int num)
        {
            Console.WriteLine(num);
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