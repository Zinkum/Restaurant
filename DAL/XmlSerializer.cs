using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace DAL
{
    public class XmlSerializer<T> : IMySerializable<T>
    {
        public void Serialize(T[] items, string address)
        {
            File.WriteAllText(address, string.Empty);
            using (Stream stream = new FileStream(address, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                new XmlSerializer(typeof(T[])).Serialize(stream, items);
            }
        }

        public T[] Deserialize(string address)
        {
            using (Stream stream = new FileStream(address, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    return (T[])new XmlSerializer(typeof(T[])).Deserialize(stream);
                }
                catch(InvalidOperationException)
                {
                    return (T[])new object();
                }
            }
        }
    }
}
