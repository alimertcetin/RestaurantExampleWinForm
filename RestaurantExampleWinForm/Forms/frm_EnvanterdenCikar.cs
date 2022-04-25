using Restaurant.Data;
using Restaurant.Interfaces;
using System;
using System.Windows.Forms;
using XIV.InventorySystems;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_EnvanterdenCikar : Form
    {
        IInventory inventory;

        public frm_EnvanterdenCikar()
        {
            InitializeComponent();
            FormUtils.FillComboBox_WithEnum<FoodType>(cmb_ItemTypes);
            nup_Count.Minimum = 1;
        }

        public void Initialize(IInventory inventory)
        {
            this.inventory = inventory;
        }

        private void btn_Cikar_Click(object sender, EventArgs e)
        {
            string typeName = cmb_ItemTypes.Items[cmb_ItemTypes.SelectedIndex].ToString();
            FoodType type = EnumUtils.GetType<FoodType>(typeName);
            Food food = new Food(txt_ItemName.Text, 0, type);
            InventoryItem inventoryItem = new InventoryItem((int)nup_Count.Value, food);
            if (inventory.Remove(inventoryItem))
            {
                MessageBox.Show($"{food.Name} removed from inventory");
            }
            else
            {
                MessageBox.Show("Couldnt remove item");
            }
        }
    }
}
