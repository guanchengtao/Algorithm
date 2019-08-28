using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RedisDemo
{
    public static class DeserializeHelper
    {
        public static string SerializeObject<T>(T obj) where T : class
        {
            //
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                //将对象写进字节流
                jsonSerializer.WriteObject(ms, obj);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
        public static T DeserializeObject<T>(string json) where T : class
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            byte[] buffer = Encoding.Default.GetBytes(json);
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                return jsonSerializer.ReadObject(ms) as T;
            }
        }
        public static void SerializeObjectToXml<T>(T obj,string path) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(@path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public static object DeserializeXmlToObject<T>(string path) where T : class
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(@path, FileMode.OpenOrCreate))
            {
                XmlReader xmlReader = new XmlTextReader(stream);
                return formatter.Deserialize(xmlReader) as T;//反序列化
            }
        }
    }
}
