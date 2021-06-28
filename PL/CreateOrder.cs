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
    public partial class CreateOrder : Form
    {
        List<Dish> dishes;
        Order order;
        public CreateOrder(Form menu, int table)
        {
            Owner = menu.Owner;
            dishes = (Owner as MainMenu).menu.MyList;
            order = new Order(table);
            InitializeComponent();
            label1.Text = Convert.ToString(table) + " столик";
            label5.Text = "Ціна замовлення: 0 ₴";
            foreach (Dish d in dishes)
            {
                listBox2.Items.Add(d.Title);
            }
        }

        private void RecalculatePrice(int price)
        {
            label5.Text = "Ціна замовлення: " + Convert.ToString(Convert.ToInt32(label5.Text.Split(' ')[2]) + price) + " ₴";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (listBox2.SelectedItem != null)
            {
                textBox1.Text = Convert.ToString(dishes[listBox2.SelectedIndex].Price);
                textBox2.Text = Convert.ToString(dishes[listBox2.SelectedIndex].Time);
                foreach (Ingredient i in dishes[listBox2.SelectedIndex].Ingredients)
                {
                    listBox3.Items.Add(i.Name);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                order.AddDish(dishes[listBox2.SelectedIndex]);
                RecalculatePrice(dishes[listBox2.SelectedIndex].Price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                RecalculatePrice(-order.Dishes[listBox1.SelectedIndex].Price);
                order.RemoveDish(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (order.Dishes.Count > 0)
            {
                (Owner as MainMenu).orderService.Add(order);
                (Owner as MainMenu).orderService.Serialize();
                Owner.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Додайте хоча б одну страву!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
