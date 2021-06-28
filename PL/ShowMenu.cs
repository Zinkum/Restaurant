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
    public partial class ShowMenu : Form
    {
        public ShowMenu(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(200, 255, 255, 255);
            foreach (Control c in panel1.Controls)
            {
                c.BackColor = Color.Transparent;
            }
            int i = 1;
            Color BackColor = Color.FromArgb(0, 225, 225, 225);
            foreach(Dish d in (Owner as MainMenu).menu.MyList)
            {
                TextBox title = new TextBox();
                title.Size = new Size(199, 24);
                title.Location = new Point(4, 4 + 25 * i);
                title.BackColor = Color.FromArgb(255,255,255,255);
                title.Text = d.Title;
                title.ReadOnly = true;

                Label price = new Label();
                price.Size = new Size(79, 24);
                price.Location = new Point(204, 4 + 25 * i);
                price.BackColor = BackColor;
                price.Text = Convert.ToString(d.Price) + " ₴";

                Label time = new Label();
                time.Size = new Size(140, 24);
                time.Location = new Point(284, 4 + 25 * i);
                time.BackColor = BackColor;
                time.Text = Convert.ToString(d.Time) + " хв";

                ListBox ingredients = new ListBox();
                ingredients.Size = new Size(199, 24);
                ingredients.Location = new Point(425, 4 + 25 * i);
                ingredients.BackColor = Color.FromArgb(255,225,225,225);
                foreach(Ingredient ing in d.Ingredients)
                {
                    ingredients.Items.Add(ing.Name);
                }

                panel1.Controls.Add(title);
                panel1.Controls.Add(price);
                panel1.Controls.Add(time);
                panel1.Controls.Add(ingredients);

                i++;
            }
            panel1.Size = new Size(629, 8 + 25 * i);
            this.Size = new Size(669, 174 + 25 * i);
            button1.Location = new Point(260, this.Size.Height - 116);
        }

        private void ShowMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
