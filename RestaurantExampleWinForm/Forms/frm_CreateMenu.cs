using Restaurant;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XIV.InventorySystem;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_CreateMenu : Form
    {
        List<Food> foods = new List<Food>();
        public Action<RestaurantMenu> onMenuCreated;

        public frm_CreateMenu()
        {
            InitializeComponent();
        }

        public void AddFoodsToPanel(List<Food> foods)
        {
            this.foods = foods;
            flp_Ingredients.Controls.Clear();
            for (int i = 0; i < foods.Count; i++)
            {
                Food food = foods[i];
                CheckBox cb = new CheckBox();
                cb.Name = $"cb_{food.Name}";
                cb.Text = food.Name;
                flp_Ingredients.Controls.Add(cb);
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if(double.TryParse(txt_Price.Text, out var result))
            {
                List<InventoryItem> menuFoods = new List<InventoryItem>();
                foreach (CheckBox item in flp_Ingredients.Controls)
                {
                    if (!item.Checked) continue;

                    Food food = GetFoodFromList(item.Name);
                    //TODO : Add ability to change count of food - Dropdown? NumericUpDown?
                    InventoryItem inventoryItem = new InventoryItem(1, food);
                    menuFoods.Add(inventoryItem);
                }

                RestaurantMenu menu = RestaurantMenu.CreateMenu(txt_MenuName.Text, result, menuFoods.ToArray());
                onMenuCreated?.Invoke(menu);
            }
            else
            {
                MessageBox.Show("Price is not in a correct format");
            }
        }

        private Food GetFoodFromList(string foodName)
        {
            foreach (Food item in foods)
            {
                if(item.Name == foodName)
                {
                    return item;
                }    
            }
            return null;
        }
    }
}
