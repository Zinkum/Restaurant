using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public enum Class { Ingredient = 1, Menu = 2, Order = 3 };

    public class Service<T>
    {
        public List<T> MyList = new List<T>();
        IMySerializable<T> data;
        string path = "";

        public void ChooseSerializtion(int choise, Class i)
        {
            switch(choise)
            {
                case 1:
                    {
                        data = new XmlSerializer<T>();
                        switch (i)
                        {
                            case Class.Ingredient:
                                {
                                    path = "Ingredients_DB.xml";
                                    break;
                                }
                            case Class.Menu:
                                {
                                    path = "Menu.xml";
                                    break;
                                }
                            case Class.Order:
                                {
                                    path = "Orders.xml";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        public void Serialize()
        {
            if (data != null)
                data.Serialize(MyList.ToArray(), path);
        }

        public void Deserialize()
        {
            try
            {
                MyList = data.Deserialize(path).ToList<T>();
            }
            catch (Exception)
            {
                MyList = new List<T>();
            }
        }

        public void Add(T item)
        {
            MyList.Add(item);
        }

        public void Remove(int index)
        {
            MyList.RemoveAt(index);
        }

        public T this[int index]
        {
            get => MyList[index];
            set => MyList[index] = value;
        }
    }
}
