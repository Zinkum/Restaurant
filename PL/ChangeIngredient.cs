using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class ChangeIngredient : Form
    {
        List<Ingredient> list;
        List<Dish> dishes;
        public ChangeIngredient(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            list = (Owner as MainMenu).ingredientService.MyList;
            dishes = (Owner as MainMenu).menu.MyList;
            foreach (Ingredient i in list)
            {
                listBox1.Items.Add(i.Name);
            }
            if (list.Count > 0)
            {
                textBox1.Text = list[0].Name;
                textBox2.Text = Convert.ToString(list[0].Price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as MainMenu).ingredientService.MyList = list;
            Owner.Show();
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            foreach (Dish d in dishes)
            {
                bool breakBool = false;
                foreach(Ingredient i in d.Ingredients)
                {
                    if (list[listBox1.TopIndex] == i)
                    {
                        breakBool = true;
                        b = true;
                        break;
                    }
                }
                if (breakBool)
                    break;
            }
            if (!b)
            {
                list[listBox1.TopIndex].Name = textBox1.Text;
                list[listBox1.TopIndex].Price = Convert.ToInt32(textBox2.Text);
                int index = listBox1.TopIndex;
                listBox1.Items[listBox1.TopIndex] = textBox1.Text;
                listBox1.TopIndex = index;
            }
            else
            {
                MessageBox.Show("Даний інгредієнт присутній у стравах в меню. Змінення неможливе", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = list[listBox1.TopIndex].Name;
            textBox2.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = list[listBox1.TopIndex].Name;
            textBox2.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = list[listBox1.TopIndex].Name;
            textBox2.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = list[listBox1.TopIndex].Name;
            textBox2.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Text = list[listBox1.TopIndex].Name;
            textBox2.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }
    }
}
