using Restaurant.Data;
using System;
using System.Windows.Forms;
using XIV.InventorySystem;
using XIV.Utils;

public interface IItemRemoveListener
{
    void OnRemoveItem(InventoryItem inventoryItem);
}

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_EnvanterdenCikar : Form
    {
        IItemRemoveListener itemRemoveListener;

        public frm_EnvanterdenCikar()
        {
            InitializeComponent();
            FormUtils.FillComboBox_WithEnum<FoodType>(cmb_ItemTypes);
            nup_Count.Minimum = 1;
        }

        public void Initialize(IItemRemoveListener itemRemoveListener)
        {
            this.itemRemoveListener = itemRemoveListener;
        }

        private void btn_Cikar_Click(object sender, EventArgs e)
        {
            string typeName = cmb_ItemTypes.Items[cmb_ItemTypes.SelectedIndex].ToString();
            FoodType type = EnumUtils.GetType<FoodType>(typeName);
            Food food = new Food(txt_ItemName.Text, 0, type);
            InventoryItem inventoryItem = new InventoryItem((int)nup_Count.Value, food);
            itemRemoveListener.OnRemoveItem(inventoryItem);
            //TODO : We dont know is inventory has this item
            MessageBox.Show($"{food.Name} removed from inventory");
        }
    }
}
