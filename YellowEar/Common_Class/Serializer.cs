using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace YellowEar
{
    public class Serializer
    {
        /// <summary>
        /// 将对象转换成二进制数组
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static byte[] SerializeBinary(object request) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();    //创建一个内存流存储区
            formatter.Serialize(memStream, request);//将对象序列化为内存流中
            return memStream.GetBuffer();
        }
        /// <summary>
        /// 将二进制数组转换成对象
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object DeSerializeBinary(byte[] data) 
        {
            MemoryStream memoryStream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(memoryStream);//将内存流反序列化为对象
        }

    }
}
