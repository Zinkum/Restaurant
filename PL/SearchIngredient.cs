using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class SearchIngredient : Form
    {
        List<Ingredient> list;
        public SearchIngredient(Form form)
        {
            Owner = form;
            InitializeComponent();
            list = (Owner as MainMenu).ingredientService.Search(textBox1.Text);
            foreach (Ingredient i in list)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (list[listBox1.SelectedIndex] != null)
                {
                    textBox2.Text = list[listBox1.SelectedIndex].Name;
                    textBox3.Text = Convert.ToString(list[listBox1.SelectedIndex].Price);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                list = (Owner as MainMenu).ingredientService.Search(textBox1.Text);
            }
            else
            {
                list = (Owner as MainMenu).ingredientService.MyList;
            }
            listBox1.Items.Clear();
            foreach (Ingredient i in list)
            {
                listBox1.Items.Add(i.Name);
            }
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void SearchIngredient_Load(object sender, EventArgs e)
        {

        }
    }
}
