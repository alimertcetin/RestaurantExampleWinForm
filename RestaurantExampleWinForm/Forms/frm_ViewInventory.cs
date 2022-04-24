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
    public interface IInventoryHolder
    {
        List<InventoryItem> GetInventoryItems();
        void AddListener(IInventoryListener inventoryListener);
        void RemoveListener(IInventoryListener inventoryListener);
    }
    public interface IInventoryListener
    {
        IInventoryHolder InventoryHolder { get; }
        void OnInventoryChanged();
    }

    public partial class frm_ViewInventory : Form, IInventoryListener
    {
        public IInventoryHolder InventoryHolder { get; private set; }

        public frm_ViewInventory()
        {
            InitializeComponent();
        }

        public void Initialize(IInventoryHolder inventoryHolder)
        {
            this.InventoryHolder = inventoryHolder;
            this.InventoryHolder.AddListener(this);
            RefreshGrid(this.InventoryHolder.GetInventoryItems());
        }

        public void OnInventoryChanged()
        {
            RefreshGrid(this.InventoryHolder.GetInventoryItems());
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
