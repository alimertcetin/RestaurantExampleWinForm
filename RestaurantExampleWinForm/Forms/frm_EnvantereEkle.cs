using Restaurant.Data;
using System;
using System.Windows.Forms;
using XIV.InventorySystem;
using XIV.Utils;

public interface IItemAddListener
{
    void OnAddItem(InventoryItem inventoryItem);
}

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_EnvantereEkle : Form
    {
        IItemAddListener itemAddListener;

        public frm_EnvantereEkle()
        {
            InitializeComponent();
            FormUtils.FillListControl_WithEnum<FoodType>(cmb_ItemTypes);
            nup_Count.Minimum = 1;
        }

        public void Initialize(IItemAddListener itemAddListener)
        {
            this.itemAddListener = itemAddListener;
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            if(double.TryParse(txt_ItemPrice.Text, out double result))
            {
                string typeName = cmb_ItemTypes.Items[cmb_ItemTypes.SelectedIndex].ToString();
                FoodType type = EnumUtils.GetType<FoodType>(typeName);
                Food food = new Food(txt_ItemName.Text, result, type);
                InventoryItem inventoryItem = new InventoryItem((int)nup_Count.Value, food);
                itemAddListener.OnAddItem(inventoryItem);
                MessageBox.Show($"{food.Name} added to inventory");
            }
            else
            {
                MessageBox.Show("Item price is not in a correct format");
            }
        }
    }
}