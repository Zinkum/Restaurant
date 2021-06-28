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
    public partial class ChangeDish : Form
    {
        List<Dish> dishes;
        List<Ingredient> available;
        public ChangeDish(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            dishes = (Owner as MainMenu).menu.MyList;
            available = (Owner as MainMenu).ingredientService.MyList;
            foreach (Dish d in dishes)
            {
                listBox3.Items.Add(d.Title);
            }
            if (dishes.Count > 0)
            {
                textBox1.Text = dishes[0].Title;
                textBox2.Text = Convert.ToString(dishes[0].Price);
                textBox3.Text = Convert.ToString(dishes[0].Time);
                foreach(Ingredient i in dishes[0].Ingredients)
                {
                    listBox1.Items.Add(i.Name);
                }
            }
            foreach(Ingredient i in available)
            {
                listBox2.Items.Add(i.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dishes[listBox3.TopIndex].ChangeTitle(textBox1.Text);
            dishes[listBox3.TopIndex].ChangePrice(Convert.ToInt32(textBox2.Text));
            dishes[listBox3.TopIndex].ChangePreparingTime(Convert.ToInt32(textBox3.Text));
            listBox3.Items[listBox3.TopIndex] = textBox1.Text;
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

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = dishes[listBox3.TopIndex].Title;
            textBox2.Text = Convert.ToString(dishes[listBox3.TopIndex].Price);
            textBox3.Text = Convert.ToString(dishes[listBox3.TopIndex].Time);
            listBox1.Items.Clear();
            foreach(Ingredient i in dishes[listBox3.TopIndex].Ingredients)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void listBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dishes[listBox3.TopIndex].Title;
            textBox2.Text = Convert.ToString(dishes[listBox3.TopIndex].Price);
            textBox3.Text = Convert.ToString(dishes[listBox3.TopIndex].Time);
            listBox1.Items.Clear();
            foreach (Ingredient i in dishes[listBox3.TopIndex].Ingredients)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void listBox3_Click(object sender, EventArgs e)
        {
            textBox1.Text = dishes[listBox3.TopIndex].Title;
            textBox2.Text = Convert.ToString(dishes[listBox3.TopIndex].Price);
            textBox3.Text = Convert.ToString(dishes[listBox3.TopIndex].Time);
            listBox1.Items.Clear();
            foreach (Ingredient i in dishes[listBox3.TopIndex].Ingredients)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dishes[listBox3.TopIndex].Title;
            textBox2.Text = Convert.ToString(dishes[listBox3.TopIndex].Price);
            textBox3.Text = Convert.ToString(dishes[listBox3.TopIndex].Time);
            listBox1.Items.Clear();
            foreach (Ingredient i in dishes[listBox3.TopIndex].Ingredients)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void listBox3_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Text = dishes[listBox3.TopIndex].Title;
            textBox2.Text = Convert.ToString(dishes[listBox3.TopIndex].Price);
            textBox3.Text = Convert.ToString(dishes[listBox3.TopIndex].Time);
            listBox1.Items.Clear();
            foreach (Ingredient i in dishes[listBox3.TopIndex].Ingredients)
            {
                listBox1.Items.Add(i.Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (Owner as MainMenu).menu.MyList = dishes;
            Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                dishes[listBox3.TopIndex].AddIngredient(available[listBox2.SelectedIndex]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                dishes[listBox3.TopIndex].RemoveIngredient(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
