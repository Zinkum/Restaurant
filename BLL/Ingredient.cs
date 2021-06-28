using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    [XmlRoot("Ingredient")]
    public class Ingredient
    {
        private string name;
        private int price;

        [XmlAttribute("Name")]
        public string Name { get => name; set => name = value; }
        [XmlAttribute("Price")]
        public int Price { get => price; set => price = value; }

        public Ingredient(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public Ingredient(string name)
        {
            this.name = name;
            price = 0;
        }

        public Ingredient()
        {
            name = "";
            price = 0;
        }
        
        public void Change(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public void ChangeName(string name) => this.name = name;

        public void ChangePrice(int price) => this.price = price;
    }
}
