using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IMySerializable<T>
    {
        void Serialize(T[] items, string address);
        T[] Deserialize(string address);
    }
}
