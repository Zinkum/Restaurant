using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL
{
    [XmlRoot("Dish")]
    public class Dish
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private int price;
        private string title;
        private int time; //in minutes

        [XmlArray("Ingredients"), XmlArrayItem("Ingredient", typeof(Ingredient))]
        public Ingredient[] IngredientsArray { get => ingredients.ToArray(); set => ingredients = value.ToList(); }

        [XmlIgnore]
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }

        [XmlAttribute("Title")]
        public string Title { get => title; set => title = value; }

        [XmlAttribute("Price")]
        public int Price { get => price; set => price = value; }

        [XmlAttribute("Time")]
        public int Time { get => time; set => time = value; }

        public Dish(string title, int price, int time, params Ingredient[] ingredients)
        {
            this.title = title;
            this.price = price;
            this.time = time;
            foreach (Ingredient ing in ingredients)
                this.ingredients.Add(ing);
        }

        public Dish()
        {
            title = "";
            price = 0;
            time = 0;
        }

        public void AddIngredient(Ingredient ingredient) => ingredients.Add(ingredient);

        public void RemoveIngredient(int index) => ingredients.RemoveAt(index);

        public void ChangeTitle(string newTitle) => this.title = newTitle;

        public void ChangePrice(int newPrice) => this.price = newPrice;

        public void ChangePreparingTime(int newTime) => this.time = newTime; //in minutes
    }
}
