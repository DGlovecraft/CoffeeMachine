using System;
using System.Windows.Forms;

namespace WaterShop
{
    public partial class Form1 : Form
    {
        private CoffeeMachine coffeeMachine;

        public Form1()
        {
            InitializeComponent();
            coffeeMachine = new CoffeeMachine();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            water_ID.Text = coffeeMachine.Ingredients["Water"].Quantity.ToString();
            coffee_ID.Text = coffeeMachine.Ingredients["Coffee"].Quantity.ToString();
            Hot_Milk_ID.Text = coffeeMachine.Ingredients["Hot_Milk"].Quantity.ToString();
            chocolate_ID.Text = coffeeMachine.Ingredients["Chocolate"].Quantity.ToString();
        }

        private void MakeCoffee(string type)
        {
            if (coffeeMachine.MakeCoffee(type))
            {
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("ส่วนผสมไม่พอ!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void late_button_Click(object sender, EventArgs e)
        {
            MakeCoffee("Late");
        }

        private void mocca_button_Click(object sender, EventArgs e)
        {
            MakeCoffee("Mocca");
        }

        private void americano_button_Click(object sender, EventArgs e)
        {
            MakeCoffee("Americano");
        }

        private void black_button_Click(object sender, EventArgs e)
        {
            MakeCoffee("Black");
        }

        private void upstock_Click(object sender, EventArgs e)
        {
            foreach (var ingredient in coffeeMachine.Ingredients.Values)
            {
                ingredient.Refill(500);
            }
            UpdateDisplay();
        }
    }
}
