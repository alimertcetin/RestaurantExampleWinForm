using Restaurant;
using Restaurant.Data;
using Restaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystems;
using XIV.SaveSystems;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_MainForm : Form, IMenuListener
    {
        #region Custom Methods
        Inventory inventory;
        const string INVENTORY_PATH = "inventory.bin";

        MenuCollection restaurantMenu;
        const string MENU_PATH = "menu.bin";

        List<Order> orderList = new List<Order>();

        private void RefreshFormControls()
        {
            RefreshOrderList();
            RefreshMenuCmb();
            RefreshFlpSize();
        }

        private void RefreshOrderList(bool keepSelection = false)
        {
            int selectedIndex = -1;
            if (keepSelection)
            {
                selectedIndex = lstb_OrderList.SelectedIndex;
            }
            lstb_OrderList.Items.Clear();
            for (int i = 0; i < orderList.Count; i++)
            {
                lstb_OrderList.Items.Add(orderList[i].ToString());
            }
            if (keepSelection && selectedIndex < lstb_OrderList.Items.Count && selectedIndex > -1)
            {
                lstb_OrderList.SelectedIndex = selectedIndex;
            }
        }

        private void RefreshMenuCmb()
        {
            int selectedIndex = cmb_Menu.SelectedIndex;
            if (selectedIndex < 0) selectedIndex = 0;

            cmb_Menu.Items.Clear();
            List<string> menuNames = restaurantMenu.GetMenuList();
            for (int i = 0; i < menuNames.Count; i++)
            {
                cmb_Menu.Items.Add(menuNames[i]);
            }

            if (selectedIndex < cmb_Menu.Items.Count)
            {
                cmb_Menu.SelectedIndex = selectedIndex;
            }
        }

        private void RefreshFlpSize()
        {
            if (cmb_Menu.SelectedIndex == -1) return;

            string menuName = cmb_Menu.Items[cmb_Menu.SelectedIndex].ToString();
            List<MenuSize> sizeOptions = restaurantMenu.GetAvailableSize(menuName);

            string previousSelected = string.Empty;
            if (FlpUtils.GetSelectedRadio(flp_Size, out var selectedRb))
            {
                previousSelected = selectedRb.Text;
            }

            FlpUtils.FillWithEnumList<MenuSize, RadioButton>(flp_Size, sizeOptions);
            //We have to set selection after we refresh the panel
            FlpUtils.SetSelectedRadio(flp_Size, previousSelected);

        }

        private void CancelOrder(int orderIndex)
        {
            double cancelPrice = 0;

            Order order = orderList[orderIndex];
            orderList.RemoveAt(orderIndex);

            List<InventoryItem> items = restaurantMenu.GetItemsOf(order.MenuName);
            double menuPrice = restaurantMenu.GetPriceOf(order.MenuName);
            for (int i = 0; i < order.MenuCount; i++)
            {
                cancelPrice += menuPrice;
                for (int j = 0; j < items.Count; j++)
                {
                    inventory.Add(items[j]);
                }
            }
            double currentPrice = double.Parse(lbl_TotalPrice.Text) - cancelPrice;
            lbl_TotalPrice.Text = currentPrice.ToString();
        }

        public void OnMenuChanged(IMenuCollection menu)
        {
            RefreshFormControls();
        }

        #endregion

        #region form callbacks

        public frm_MainForm()
        {
            InitializeComponent();
        }

        private void frm_MainForm_Load(object sender, EventArgs e)
        {
            SaveSystem.Load(ref inventory, INVENTORY_PATH);
            SaveSystem.Load(ref restaurantMenu, MENU_PATH);

            restaurantMenu.AddListener(this);
            nup_menuAmount.Minimum = 1;
            RefreshFormControls();
        }

        private void frm_MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = orderList.Count - 1; i >= 0; i--)
            {
                CancelOrder(i);
            }
            SaveSystem.Save(inventory, INVENTORY_PATH);
            SaveSystem.Save(restaurantMenu, MENU_PATH);
        }

        private void ts_MalzemeEkle_Click(object sender, EventArgs e)
        {
            frm_EnvantereEkle form = FormUtils.OpenForm<frm_EnvantereEkle>(this.MdiParent);
            form.Initialize(inventory);
        }

        private void ts_MenuOlustur_Click(object sender, EventArgs e)
        {
            frm_CreateMenu form = FormUtils.OpenForm<frm_CreateMenu>(this.MdiParent);
            form.Initialize(inventory, restaurantMenu);
        }

        private void ts_MalzemeCikar_Click(object sender, EventArgs e)
        {
            frm_EnvanterdenCikar form = FormUtils.OpenForm<frm_EnvanterdenCikar>(this.MdiParent);
            form.Initialize(inventory);
        }

        private void btn_SiparisEkle_Click(object sender, EventArgs e)
        {
            if (!FlpUtils.GetSelectedRadio(flp_Size, out RadioButton radioButton))
            {
                MessageBox.Show("Select a menu size");
                return;
            }

            MenuSize menuSize = EnumUtils.GetType<MenuSize>(radioButton.Text);

            string menuName = cmb_Menu.Items[cmb_Menu.SelectedIndex].ToString();

            int orderCount = (int)nup_menuAmount.Value;
            if (restaurantMenu.Contains(menuName))
            {
                List<InventoryItem> menuItems = restaurantMenu.GetItemsOf(menuName);
                if (inventory.IsLegitOrder(orderCount, menuItems))
                {
                    double totalMenuPrice = double.Parse(lbl_TotalPrice.Text);
                    double menuPrice = restaurantMenu.GetPriceOf(menuName);
                    for (int i = 0; i < orderCount; i++)
                    {
                        totalMenuPrice += menuPrice;
                        for (int j = 0; j < menuItems.Count; j++)
                        {
                            if (!inventory.Remove(menuItems[j]))
                            {
                                MessageBox.Show("Couldnt remove item from inventory : " + menuItems[j]);
                                return;
                            }
                        }
                    }
                    lbl_TotalPrice.Text = totalMenuPrice.ToString();
                    Order order = new Order(orderList.Count, menuName, menuSize, orderCount, totalMenuPrice);
                    orderList.Add(order);
                    RefreshOrderList();
                }
                else
                {
                    MessageBox.Show("Sorry, this menu is not available right now");
                }
            }
            else
            {
                MessageBox.Show("Sorry, something went wrong. It seems we cant find this menu in our database");
            }
        }

        private void cmb_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFlpSize();
        }

        private void cmb_Menu_SizeChanged(object sender, EventArgs e)
        {
            RefreshFlpSize();
            if (cmb_Menu.Items.Count > 0)
            {
                cmb_Menu.SelectedIndex = cmb_Menu.Items.Count - 1;
            }
        }

        private void ts_EnvanterGoruntule_Click(object sender, EventArgs e)
        {
            frm_ViewInventory form = FormUtils.OpenForm<frm_ViewInventory>(this.MdiParent);
            form.Initialize(inventory);
        }

        private void btn_CancelSelected_Click(object sender, EventArgs e)
        {
            int selectedOrderIndex = lstb_OrderList.SelectedIndex;
            if(selectedOrderIndex < 0)
            {
                MessageBox.Show("You didnt select an order");
                return;
            }

            CancelOrder(selectedOrderIndex);
            RefreshOrderList(true);
        }

        private void ts_MenuGoruntule_Click(object sender, EventArgs e)
        {
            frm_ViewMenu form = FormUtils.OpenForm<frm_ViewMenu>(this.MdiParent);
            form.Initialize(restaurantMenu);
        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            inventory.AddMoney(double.Parse(lbl_TotalPrice.Text));
            lbl_TotalPrice.Text = "0";
        }
    }

    #endregion
}
