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
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_CreateMenu : Form
    {
        List<Food> foods = new List<Food>();
        public Action<RestaurantMenu> OnRestaurantMenuCreated;

        public frm_CreateMenu()
        {
            InitializeComponent();
            FormUtils.FillFlp_CheckBoxWithEnum<MenuSize>(flp_MenuSize);
        }

        public void Initialize(List<Food> foods)
        {
            this.foods = foods;
            FormUtils.FillFlp_CheckBoxWithEnum<MenuSize>(flp_MenuSize);
        }

        public void ClearFlowLayout()
        {
            flp_Ingredients.Controls.Clear();
            this.foods.Clear();
        }

        public void AddFoodToPanel(Food food)
        {
            CheckBox cb = new CheckBox();
            cb.Name = $"cb_{food.Name}";
            cb.Text = food.Name;
            flp_Ingredients.Controls.Add(cb);
            this.foods.Add(food);
        }

        public void RemoveFoodFromPanel(Food food)
        {
            for (int i = flp_Ingredients.Controls.Count - 1; i >= 0; i--)
            {
                if (flp_Ingredients.Controls[i] is CheckBox item && item.Name == $"cb_{food.Name}")
                {
                    flp_Ingredients.Controls.RemoveAt(i);
                    foods.Remove(food);
                }
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            List<MenuSize> selectedSizeList = new List<MenuSize>();
            for (int i = 0; i < flp_MenuSize.Controls.Count; i++)
            {
                if (flp_MenuSize.Controls[i] is CheckBox item)
                {
                    MenuSize selectedType = EnumUtils.GetType<MenuSize>(item.Text);
                    selectedSizeList.Add(selectedType);
                }
            }
            if(selectedSizeList.Count == 0)
            {
                MessageBox.Show("You have to select at least 1 size");
                return;
            }

            if (double.TryParse(txt_Price.Text, out var result))
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

                RestaurantMenu menu = RestaurantMenu.CreateMenu(txt_MenuName.Text, result,
                    selectedSizeList, menuFoods.ToArray());
                OnRestaurantMenuCreated?.Invoke(menu);
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
