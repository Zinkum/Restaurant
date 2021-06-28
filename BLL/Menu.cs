using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Xml.Serialization;

namespace BLL
{
    public class Menu : Service<Dish>
    {
        public List<Dish> Output() => this.MyList;
    }
}
