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

    public partial class FinishOrder : Form
    {
        List<Order> list;
        Order order;
        int index;
        public FinishOrder(Form menu)
        {
            Owner = menu;
            InitializeComponent();
            list = (Owner as MainMenu).orderService.MyList;
            foreach (Order o in list)
            {
                listBox1.Items.Add(Convert.ToString(o.Table) + " столик");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                if (list[listBox1.SelectedIndex] != null)
                {
                    index = listBox1.SelectedIndex;
                    order = list[listBox1.SelectedIndex];
                    listBox2.Items.Clear();
                    foreach (Dish d in order.Dishes)
                    {
                        listBox2.Items.Add(d.Title);
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    listBox3.Items.Clear();
                    label8.Text = "Загальна вартість: " + order.TotalPrice + " ₴";
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (order != null && listBox2.SelectedIndex >= 0)
            {
                if (order.Dishes[listBox2.SelectedIndex] != null)
                {
                    textBox2.Text = order.Dishes[listBox2.SelectedIndex].Title;
                    textBox3.Text = Convert.ToString(order.Dishes[listBox2.SelectedIndex].Price);
                    textBox4.Text = Convert.ToString(order.Dishes[listBox2.SelectedIndex].Time);
                    listBox3.Items.Clear();
                    foreach (Ingredient i in order.Dishes[listBox2.SelectedIndex].Ingredients)
                    {
                        listBox3.Items.Add(i.Name);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                (Owner as MainMenu).orderService.Remove(index);
                (Owner as MainMenu).orderService.Serialize();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                foreach (Order o in list)
                {
                    listBox1.Items.Add(Convert.ToString(o.Table) + " столик");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Спочатку виберіть замовлення, яке потрібно закрити!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
