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
    public partial class AvailableTables : Form
    {
        Label previousLabel;

        List<Order> list;
        bool[] layout = new bool[22];

        public AvailableTables(Form menu)
        {
            Owner = menu.Owner;
            InitializeComponent();
            list = (Owner as MainMenu).orderService.MyList;
            for(int i = 0; i < list.Count; i++)
            {
                layout[list[i].Table - 1] = true;
            }
            for(int i = 1; i <= 6; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(49, 49);
                lbl.Location = new Point(4 + 50 * (i - 1), 4);
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = Convert.ToString(i);
                lbl.BackColor = layout[i - 1] ? Color.Red : Color.LimeGreen;
                lbl.Click += lbl_Click;
                panel1.Controls.Add(lbl);
            }
            for(int i = 1; i <= 4; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(49, 49);
                lbl.Location = new Point(4, 104 + (50 * (i - 1)));
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = Convert.ToString(i + 6);
                lbl.BackColor = layout[i + 5] ? Color.Red : Color.LimeGreen;
                lbl.Click += lbl_Click;
                panel1.Controls.Add(lbl);
            }
            for (int i = 1; i <= 4; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(49, 49);
                lbl.Location = new Point(104, 104 + (50 * (i - 1)));
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = Convert.ToString(i + 10);
                lbl.BackColor = layout[i + 9] ? Color.Red : Color.LimeGreen;
                lbl.Click += lbl_Click;
                panel1.Controls.Add(lbl);
            }
            for (int i = 1; i <= 4; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(49, 49);
                lbl.Location = new Point(154, 104 + (50 * (i - 1)));
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = Convert.ToString(i + 14);
                lbl.BackColor = layout[i + 13] ? Color.Red : Color.LimeGreen;
                lbl.Click += lbl_Click;
                panel1.Controls.Add(lbl);
            }
            for (int i = 1; i <= 4; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(49, 49);
                lbl.Location = new Point(254, 104 + (50 * (i - 1)));
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = Convert.ToString(i + 18);
                lbl.BackColor = layout[i + 17] ? Color.Red : Color.LimeGreen;
                lbl.Click += lbl_Click;
                panel1.Controls.Add(lbl);
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            Color color = lbl.BackColor;
            if (color != Color.Red)
            {
                if (previousLabel != null)
                    previousLabel.BackColor = Color.LimeGreen;
                color = Color.Yellow;
                previousLabel = (Label)sender;
                lbl.BackColor = color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new CreateOrder(this, Convert.ToInt32(previousLabel.Text));
            form.Show();
            Close();
        }
    }
}
