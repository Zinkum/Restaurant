using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL
{
    public class OrderService : Service<Order>
    {
        public List<Order> Search(string search)
        {
            search = search.ToLower();
            List<Order> SearchList = new List<Order>();
            Regex regex = new Regex(search);
            foreach (Order o in MyList)
            {
                foreach (Dish d in o.Dishes)
                {
                    if (regex.IsMatch(d.Title.ToLower()))
                    {
                        SearchList.Add(o);
                        break;
                    }
                }
            }
            return SearchList;
        }

        public List<Order> Search(int search)
        {
            List<Order> SearchList = new List<Order>();
            foreach (Order o in MyList)
            {
                if(search == o.Table)
                {
                    SearchList.Add(o);
                    break;
                }
            }
            return SearchList;
        }
    }
}
