using Restaurant;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystem;
using XIV.Utils;

public interface IMenuCreationListener
{
    void OnRestaurantMenuCreated(RestaurantMenu createdMenu);
}

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_CreateMenu : Form
    {
        List<Food> foods = new List<Food>();
        IMenuCreationListener menuCreationListener;

        public frm_CreateMenu()
        {
            InitializeComponent();
            FlowLayoutUtils.FillWithEnum<MenuSize, CheckBox>(flp_MenuSize);
        }

        public void Initialize(List<Food> foods, IMenuCreationListener creationListener)
        {
            ClearFlowLayout();
            this.foods = foods;
            FlowLayoutUtils.FillWithEnum<MenuSize, CheckBox>(flp_MenuSize);
            menuCreationListener = creationListener;
            for (int i = 0; i < this.foods.Count; i++)
            {
                AddFoodToPanel(this.foods[i]);
            }
        }

        public void ClearFlowLayout()
        {
            flp_Ingredients.Controls.Clear();
            this.foods.Clear();
        }

        private void AddFoodToPanel(Food food)
        {
            CheckBox cb = new CheckBox();
            cb.Name = $"cb_{food.Name}";
            cb.Text = food.Name;
            flp_Ingredients.Controls.Add(cb);
        }

        public void RemoveFoodFromPanel(Food food)
        {
            for (int i = flp_Ingredients.Controls.Count - 1; i >= 0; i--)
            {
                if (flp_Ingredients.Controls[i] is CheckBox item && item.Text == food.Name)
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
                if (flp_MenuSize.Controls[i] is CheckBox item && item.Checked)
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
            if (!double.TryParse(txt_Price.Text, out var result))
            {
                MessageBox.Show("Price is not in a correct format");
                return;
            }

            List<InventoryItem> menuFoods = new List<InventoryItem>();
            foreach (CheckBox item in flp_Ingredients.Controls)
            {
                if (!item.Checked) continue;

                Food food = GetFoodFromList(item.Text);
                //TODO : Add ability to change count of food - Dropdown? NumericUpDown?
                InventoryItem inventoryItem = new InventoryItem(1, food);
                menuFoods.Add(inventoryItem);
            }
            if(menuFoods.Count == 0)
            {
                MessageBox.Show("You didnt select any food to create a menu");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_MenuName.Text))
            {
                MessageBox.Show("Menu Name not in a correct format");
                return;
            }

            RestaurantMenu menu = RestaurantMenu.CreateMenu(txt_MenuName.Text, result,
                selectedSizeList, menuFoods.ToArray());
            
            menuCreationListener.OnRestaurantMenuCreated(menu);
            MessageBox.Show($"Created a menu : {txt_MenuName.Text}");
        }

        private Food GetFoodFromList(string foodName)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                if (foods[i].Name == foodName)
                {
                    return foods[i];
                }    
            }
            return null;
        }
    }
}