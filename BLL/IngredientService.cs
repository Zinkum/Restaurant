using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL
{
    public class IngredientService : Service<Ingredient>
    {
        public List<Ingredient> Search(string search)
        {
            search = search.ToLower();
            List<Ingredient> SearchList = new List<Ingredient>();
            Regex regex = new Regex(search);
            foreach (Ingredient i in MyList)
            {
                if(regex.IsMatch(i.Name.ToLower()))
                {
                    SearchList.Add(i);
                }
            }
            return SearchList;
        }
    }
}
