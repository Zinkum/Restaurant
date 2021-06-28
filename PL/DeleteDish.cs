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
    public partial class DeleteDish : Form
    {
        List<Dish> dishes;
        public DeleteDish(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            dishes = (Owner as MainMenu).menu.MyList;

            foreach (Dish d in dishes)
            {
                listBox1.Items.Add(d.Title);
            }

            if (dishes.Count > 0)
            {
                textBox1.Text = Convert.ToString(dishes[0].Price);
                textBox2.Text = Convert.ToString(dishes[0].Time);
                foreach(Ingredient i in dishes[0].Ingredients)
                {
                    listBox2.Items.Add(i.Name);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
            textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
            listBox2.Items.Clear();
            foreach (Ingredient i in dishes[listBox1.TopIndex].Ingredients)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
            textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
            listBox2.Items.Clear();
            foreach (Ingredient i in dishes[listBox1.TopIndex].Ingredients)
            {
                listBox2.Items.Add(i.Name);
            }
        }

            private void listBox3_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
            textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
            listBox2.Items.Clear();
            foreach (Ingredient i in dishes[listBox1.TopIndex].Ingredients)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
            textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
            listBox2.Items.Clear();
            foreach (Ingredient i in dishes[listBox1.TopIndex].Ingredients)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
            textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
            listBox2.Items.Clear();
            foreach (Ingredient i in dishes[listBox1.TopIndex].Ingredients)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.TopIndex;
            dishes.RemoveAt(index);
            listBox1.Items.RemoveAt(index);
            listBox1.TopIndex = index;
            listBox2.Items.Clear();
            if (dishes.Count > 0)
            {
                textBox1.Text = Convert.ToString(dishes[listBox1.TopIndex].Price);
                textBox2.Text = Convert.ToString(dishes[listBox1.TopIndex].Time);
                foreach(Ingredient i in dishes[listBox1.TopIndex].Ingredients)
                {
                    listBox2.Items.Add(i.Name);
                }
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
    }
}
