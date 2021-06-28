using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Order
    {
        private List<Dish> dishes = new List<Dish>();
        private int table;

        public int TotalPrice { get { int price = 0; foreach (Dish d in dishes) { price += d.Price; } return price; } }
        public List<Dish> Dishes { get => dishes; set { dishes = value; } }
        public int Table { get => table; set { table = value; } }

        public Order(int table) => this.table = table;

        public Order() => table = 0;

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void RemoveDish(int index)
        {
            Dishes.RemoveAt(index);
        }

        public void ChangeTable(int newTable) => this.table = newTable;
    }
}
