using Restaurant.Data;
using Restaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystems;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_CreateMenu : Form, IInventoryListener
    {
        private IInventory inventory;
        private IMenuCollection menu;

        public frm_CreateMenu()
        {
            InitializeComponent();
            FlpUtils.FillWithEnum<MenuSize, CheckBox>(flp_MenuSize);
        }

        public void Initialize(IInventory inventory, IMenuCollection menu)
        {
            this.inventory?.RemoveListener(this);
            this.inventory = inventory;
            this.inventory.AddListener(this);
            this.menu = menu;

            RefreshFlpIngredients(inventory);
            FlpUtils.FillWithEnum<MenuSize, CheckBox>(flp_MenuSize);
        }

        public void RefreshFlpIngredients(IInventory inventory)
        {
            flp_Ingredients.Controls.Clear();

            List<Food> foods = inventory.GetItems().ToFoodList();
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
            List<MenuSize> selectedSizeList = new List<MenuSize>();
            FlpUtils.GetSelectedCheckBoxes(flp_MenuSize, out List<CheckBox> selectedCbList);
            for (int i = 0; i < selectedCbList.Count; i++)
            {
                MenuSize selectedType = EnumUtils.GetType<MenuSize>(selectedCbList[i].Text);
                selectedSizeList.Add(selectedType);
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
            FlpUtils.GetSelectedCheckBoxes(flp_Ingredients, out List<CheckBox> selectedIngredientList);
            for (int i = 0; i < selectedIngredientList.Count; i++)
            {
                Food selectedFood = GetFoodFromList(selectedIngredientList[i].Text, inventory.GetItems().ToFoodList());
                //TODO : Add ability to change count of food - Dropdown? NumericUpDown?
                InventoryItem inventoryItem = new InventoryItem(1, selectedFood);
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

            Restaurant.Menu menu = Restaurant.Menu.CreateMenu(txt_MenuName.Text, result,
                selectedSizeList, menuFoods.ToArray());

            if (this.menu.Add(menu.Name, menu))
            {
                MessageBox.Show($"Created a menu : {txt_MenuName.Text}");
            }
        }

        private Food GetFoodFromList(string foodName, List<Food> foods)
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

        public void OnInventoryChanged(IInventory inventory)
        {
            RefreshFlpIngredients(inventory);
        }

        private void frm_CreateMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.inventory?.RemoveListener(this);
        }
    }
}