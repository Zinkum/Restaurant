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
    public partial class AddDish : Form
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        List<Ingredient> available;

        public AddDish(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            available = (Owner as MainMenu).ingredientService.MyList;
            foreach(Ingredient i in available)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                ingredients.Add(available[listBox2.SelectedIndex]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ingredients.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool b = false;
            string message = "";
            if (textBox1.Text == "")
            {
                b = true;
                message += "Пуста назва страви! Будь ласка, введіть назву\n";
            }
            if (textBox2.Text == "")
            {
                b = true;
                message += "Пуста ціна страви! Будь ласка, введіть ціну\n";
            }
            if (textBox3.Text == "")
            {
                b = true;
                message += "Пустий час приготування страви! Будь ласка, введіть час приготування\n";
            }
            if (ingredients.Count == 0)
            {
                b = true;
                message += "Cтрава не містить жодного інгредієнту! Будь ласка, виберіть інгредієнти\n";
            }
            if (b)
            {
                MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (Owner as MainMenu).menu.Add(new Dish(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), ingredients.ToArray()));
                button4_Click(button4, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
    }
}
