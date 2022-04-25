using Restaurant.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystems;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_ViewInventory : Form, IInventoryListener
    {
        public frm_ViewInventory()
        {
            InitializeComponent();
        }

        public void Initialize(IInventory inventory)
        {
            inventory.AddListener(this);
            RefreshGrid(inventory.GetItems());
        }

        public void OnInventoryChanged(IInventory inventory)
        {
            RefreshGrid(inventory.GetItems());
        }

        private void RefreshGrid(List<InventoryItem> itemList)
        {
            dgv_Inventory.Columns.Clear();
            dgv_Inventory.ColumnCount = 3;
            dgv_Inventory.Columns[0].Name = "Name";
            dgv_Inventory.Columns[1].Name = "Amount";
            dgv_Inventory.Columns[2].Name = "Type";

            dgv_Inventory.Rows.Clear();
            foreach (InventoryItem item in itemList)
            {
                dgv_Inventory.Rows.Add(item.Item.Name, item.Amount, item.Item.FoodType.ToString());
            }
        }
    }
}
