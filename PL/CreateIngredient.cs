using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class CreateIngredient : Form
    {
        public CreateIngredient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            string message = "";
            if(textBox1.Text == "")
            {
                b = true;
                message += "Пуста назва інгредієнта! Будь ласка, введіть назву\n";
            }
            if (textBox2.Text == "")
            {
                b = true;
                message += "Пуста ціна інгредієнта! Будь ласка, введіть ціну\n";
            }
            if(b)
            {
                MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                (Owner as MainMenu).ingredientService.Add(new BLL.Ingredient(textBox1.Text, Convert.ToInt32(textBox2.Text)));
                button2_Click(button2, e);
            }
        }

        private void textbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }
    }
}
