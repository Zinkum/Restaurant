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
    public partial class DeleteIngredient : Form
    {
        List<Ingredient> list;
        List<Dish> dishes;

        public DeleteIngredient(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            list = (Owner as MainMenu).ingredientService.MyList;
            dishes = (Owner as MainMenu).menu.MyList;
            foreach (Ingredient i in list)
            {
                listBox1.Items.Add(i.Name);
            }
            if (listBox1.Items.Count > 0)
            {
                textBox1.Text = Convert.ToString(list[0].Price);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as MainMenu).ingredientService.MyList = list;
            Owner.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            foreach (Dish d in dishes)
            {
                bool breakBool = false;
                foreach (Ingredient i in d.Ingredients)
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
                list.RemoveAt(listBox1.TopIndex);
                int index = listBox1.TopIndex;
                listBox1.Items.RemoveAt(listBox1.TopIndex);
                listBox1.TopIndex = index;
                if (list.Count > 0)
                    textBox1.Text = Convert.ToString(list[listBox1.TopIndex].Price);
                else
                    textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Даний інгредієнт присутній у стравах в меню. Змінення неможливе", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}