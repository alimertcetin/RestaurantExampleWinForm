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
using XIV.SaveSystems;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_MainForm : Form
    {
        Inventory inventory;
        const string INVENTORY_PATH = "inventory.bin";

        List<RestaurantMenu> menuList;
        const string MENU_PATH = "menu.bin";

        public frm_MainForm()
        {
            InitializeComponent();
        }

        private void frm_MainForm_Load(object sender, EventArgs e)
        {
            inventory = SaveSystem.Load<Inventory>(INVENTORY_PATH);
            menuList = SaveSystem.Load<List<RestaurantMenu>>(MENU_PATH);
            RefreshMenuCmb();
        }

        private void frm_MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSystem.Save(inventory, INVENTORY_PATH);
            SaveSystem.Save(menuList, MENU_PATH);
        }

        private void ts_MalzemeEkle_Click(object sender, EventArgs e)
        {
            FormUtils.TekliFormOlustur<frm_EnvantereEkle>(this.MdiParent);
            frm_EnvantereEkle form = FormUtils.GetForm<frm_EnvantereEkle>();
            form.onAddItem += inventory.Add;
            form.FormClosing += OnEnvatereEkleClosing;
        }

        private void OnEnvatereEkleClosing(object sender, FormClosingEventArgs e)
        {
            frm_EnvantereEkle form = FormUtils.GetForm<frm_EnvantereEkle>();
            form.onAddItem -= inventory.Add;
            form.FormClosing -= OnEnvatereEkleClosing;
        }

        private void ts_MenuOlustur_Click(object sender, EventArgs e)
        {
            FormUtils.TekliFormOlustur<frm_CreateMenu>(this.MdiParent);
            frm_CreateMenu form = FormUtils.GetForm<frm_CreateMenu>();
            List<InventoryItem> inventoryItems = inventory.GetItems();
            List<Food> foodList = new List<Food>();
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem inventoryItem = inventoryItems[i];
                if(inventoryItem.Item is Food)
                {
                    foodList.Add(inventoryItem.Item as Food);
                }
            }
            form.AddFoodsToPanel(foodList);
            form.onMenuCreated += OnMenuCreated;
        }

        private void OnMenuCreated(RestaurantMenu addedMenu)
        {
            bool flag = false;
            for (int i = 0; i < menuList.Count; i++)
            {
                RestaurantMenu menu = menuList[i];
                if(menu.Name == addedMenu.Name)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                menuList.Add(addedMenu);
                RefreshMenuCmb();
            }
            else
            {
                MessageBox.Show($"There is already a menu that has the same name. {addedMenu.Name}");
            }
        }

        private void RefreshMenuCmb()
        {
            cmb_Menu.Items.Clear();
            for (int i = 0; i < menuList.Count; i++)
            {
                cmb_Menu.Items.Add(menuList[i].Name);
            }
            if(cmb_Menu.SelectedIndex == -1 && cmb_Menu.Items.Count > 0)
            {
                cmb_Menu.SelectedIndex = 0;
            }
        }
    }
}