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
    public partial class MainMenu : Form
    {
        public OrderService orderService = new OrderService();
        public IngredientService ingredientService = new IngredientService();
        public BLL.Menu menu = new BLL.Menu();

        public MainMenu()
        {
            orderService.ChooseSerializtion(1, Class.Order);
            ingredientService.ChooseSerializtion(1, Class.Ingredient);
            menu.ChooseSerializtion(1, Class.Menu);

            InitializeComponent();

            orderService.Deserialize();
            ingredientService.Deserialize();
            menu.Deserialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new ShowMenu(menu);
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ingredientService.Serialize();
            menu.Serialize();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateIngredient create = new CreateIngredient();
            create.Owner = this;
            create.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new ChangeIngredient(menu);
            menu.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new AddDish(menu);
            menu.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new ChangeDish(menu);
            menu.Show();
            Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new DeleteIngredient(menu);
            menu.Show();
            Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new DeleteDish(menu);
            menu.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form menu = new Form();
            menu.Owner = this;
            menu = new AvailableTables(menu);
            menu.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FinishOrder menu = new FinishOrder(this);
            menu.Show();
            Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SearchIngredient menu = new SearchIngredient(this);
            menu.Show();
            Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SearchOrder menu = new SearchOrder(this);
            menu.Show();
            Hide();
        }
    }
}
