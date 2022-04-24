using Restaurant;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystem;
using XIV.SaveSystems;
using XIV.Utils;

namespace RestaurantExampleWinForm.Forms
{
    public partial class frm_MainForm : Form, IMenuCreationListener, IItemAddListener, IItemRemoveListener, IInventoryHolder, IMenuHolder
    {
        Inventory inventory;
        const string INVENTORY_PATH = "inventory.bin";

        MenuOfRest restaurantMenu;
        const string MENU_PATH = "menu.bin";

        List<Order> orderList = new List<Order>();
        List<IInventoryListener> inventoryListeners = new List<IInventoryListener>();
        List<IMenuListener> menuListeners = new List<IMenuListener>();

        public frm_MainForm()
        {
            InitializeComponent();
        }

        private void RefreshFlpSize()
        {
            if (cmb_Menu.SelectedIndex == -1) return;

            //menülerden şu anda seçili olanı bul
            string menuName = cmb_Menu.Items[cmb_Menu.SelectedIndex].ToString();

            //Menünün boyut seçeneklerini al
            List<MenuSize> sizeOptions = restaurantMenu.GetAvailableSize(menuName);

            string selectedTxt = string.Empty;
            //Get selected radio
            if(FlowLayoutUtils.GetSelectedRadio(flp_Size, out var selectedRb))
            {
                selectedTxt = selectedRb.Text;
            }

            //Radio button olarak flpSize'a ekle
            FlowLayoutUtils.FillWithEnumList<MenuSize, RadioButton>(flp_Size, sizeOptions);
            FlowLayoutUtils.SetSelectedRadio(flp_Size, selectedTxt);

        }

        public bool OnRestaurantMenuCreated(RestaurantMenu addedMenu)
        {
            try
            {
                restaurantMenu.Add(addedMenu.Name, addedMenu);
                RefreshFormControls();
                RefreshMenuListeners();
                return true;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
                return false;
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

        public void OnAddItem(InventoryItem inventoryItem)
        {
            inventory.Add(inventoryItem);
            RefreshListeners();
            RefreshMenuListeners();
            RefreshFormControls();
        }

        public void OnRemoveItem(InventoryItem inventoryItem)
        {
            inventory.Remove(inventoryItem.Item, inventoryItem.Amount);
            RefreshListeners();
            RefreshMenuListeners();
            RefreshFormControls();
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
            if(keepSelection && selectedIndex < lstb_OrderList.Items.Count && selectedIndex > -1)
            {
                lstb_OrderList.SelectedIndex = selectedIndex;
            }
        }

        private void RefreshFormControls()
        {
            RefreshOrderList();
            RefreshMenuCmb();
            RefreshFlpSize();
        }

        public List<InventoryItem> GetInventoryItems()
        {
            return inventory.GetItems();
        }

        public void AddListener(IInventoryListener inventoryListener)
        {
            if (!inventoryListeners.Contains(inventoryListener))
            {
                inventoryListeners.Add(inventoryListener);
            }
        }

        public void RemoveListener(IInventoryListener inventoryListener)
        {
            if (inventoryListeners.Contains(inventoryListener))
            {
                inventoryListeners.Remove(inventoryListener);
            }
        }

        private void RefreshListeners()
        {
            for (int i = 0; i < inventoryListeners.Count; i++)
            {
                inventoryListeners[i].OnInventoryChanged();
            }
        }

        private void CancelOrder(int orderIndex)
        {
            double currentPrice = double.Parse(lbl_TotalPrice.Text);
            double cancelPrice = 0;

            Order order = orderList[orderIndex];
            List<InventoryItem> items = restaurantMenu.GetItemsOf(order.MenuName);
            for (int i = 0; i < order.MenuCount; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {
                    cancelPrice += items[j].Item.Price;
                    inventory.Add(items[j]);
                }
            }
            currentPrice -= cancelPrice;
            lbl_TotalPrice.Text = currentPrice.ToString();
            orderList.RemoveAt(orderIndex);
        }

        public List<string> GetMenuList()
        {
            return restaurantMenu.GetMenuList();
        }

        public List<InventoryItem> GetItemsOf(string menuName)
        {
            return restaurantMenu.GetItemsOf(menuName);
        }

        public void AddListener(IMenuListener menuListener)
        {
            if (!menuListeners.Contains(menuListener))
            {
                menuListeners.Add(menuListener);
            }
        }

        public void RemoveListener(IMenuListener menuListener)
        {
            if (menuListeners.Contains(menuListener))
            {
                menuListeners.Remove(menuListener);
            }
        }

        private void RefreshMenuListeners()
        {
            for (int i = 0; i < menuListeners.Count; i++)
            {
                menuListeners[i].RefreshMenu();
            }
        }

        //-------------------
        //-------------------Form Callbacks

        private void frm_MainForm_Load(object sender, EventArgs e)
        {
            inventory = SaveSystem.Load<Inventory>(INVENTORY_PATH);
            restaurantMenu = SaveSystem.Load<MenuOfRest>(MENU_PATH);
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
            form.Initialize(this);
        }

        private void ts_MenuOlustur_Click(object sender, EventArgs e)
        {
            frm_CreateMenu form = FormUtils.OpenForm<frm_CreateMenu>(this.MdiParent);
            form.Initialize(this, this);
        }

        private void ts_MalzemeCikar_Click(object sender, EventArgs e)
        {
            frm_EnvanterdenCikar form = FormUtils.OpenForm<frm_EnvanterdenCikar>(this.MdiParent);
            form.Initialize(this);
        }

        private void btn_SiparisEkle_Click(object sender, EventArgs e)
        {
            //TODO : Create order, update total price, remove from inventory
            if (!FlowLayoutUtils.GetSelectedRadio(flp_Size, out RadioButton radioButton))
            {
                MessageBox.Show("Select a menu size");
                return;
            }

            MenuSize menuSize = EnumUtils.GetType<MenuSize>(radioButton.Text);

            string menuName = cmb_Menu.Items[cmb_Menu.SelectedIndex].ToString();

            int orderCount = (int)nup_menuAmount.Value;
            if(restaurantMenu.Contains(menuName))
            {
                List<InventoryItem> menuItems = restaurantMenu.GetItemsOf(menuName);
                if (inventory.IsLegitOrder(orderCount, menuItems))
                {
                    double totalMenuPrice = double.Parse(lbl_TotalPrice.Text);
                    for (int i = 0; i < menuItems.Count; i++)
                    {
                        InventoryItem menuItem = menuItems[i];
                        for (int j = 0; j < menuItem.Amount; j++)
                        {
                            totalMenuPrice += menuItem.Item.Price;
                        }
                    }
                    Order order = new Order(orderList.Count, menuName, menuSize, orderCount, totalMenuPrice);
                    orderList.Add(order);
                    lbl_TotalPrice.Text = totalMenuPrice.ToString();

                    for (int i = 0; i < orderCount; i++)
                    {
                        inventory.Remove(menuItems);
                    }
                    RefreshFormControls();
                    RefreshListeners();
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
            form.Initialize(this);
        }

        private void btn_CancelSelected_Click(object sender, EventArgs e)
        {
            int selectedOrderIndex = lstb_OrderList.SelectedIndex;
            if(selectedOrderIndex < 0)
            {
                MessageBox.Show("You didnt select an order");
                return;
            }

            //TODO :  update total price, add to inventory
            CancelOrder(selectedOrderIndex);
            RefreshOrderList(true);
            RefreshListeners();
        }

        private void ts_MenuGoruntule_Click(object sender, EventArgs e)
        {
            frm_ViewMenu form = FormUtils.OpenForm<frm_ViewMenu>(this.MdiParent);
            form.Initialize(this);
        }

        private void btn_Checkout_Click(object sender, EventArgs e)
        {
            inventory.AddMoney(double.Parse(lbl_TotalPrice.Text));
            lbl_TotalPrice.Text = "0";
        }
    }

}

[System.Serializable]
public class MenuOfRest
{
    Dictionary<string, RestaurantMenu> menu = new Dictionary<string, RestaurantMenu>();

    public void Add(string menuName, RestaurantMenu item)
    {
        menu.Add(menuName, item);
    }

    public void Remove(string menuName)
    {
        menu.Remove(menuName);
    }

    public List<string> GetMenuList()
    {
        string[] menuNames = new string[menu.Keys.Count];
        menu.Keys.CopyTo(menuNames, 0);

        List<string> nameList = new List<string>();
        for (int i = 0; i < menuNames.Length; i++)
        {
            nameList.Add(menuNames[i]);
        }
        return nameList;
    }

    public bool Contains(string menuName)
    {
        return menu.ContainsKey(menuName);
    }

    public List<InventoryItem> GetItemsOf(string menuName)
    {
        if(menu.TryGetValue(menuName, out var itemList))
        {
            return itemList.GetItems();
        }
        throw new InvalidOperationException("Couldnt find menu");
    }

    public List<MenuSize> GetAvailableSize(string menuName)
    {
        if (menu.TryGetValue(menuName, out var restaurantMenu))
        {
            return restaurantMenu.AvailableSizeList;
        }
        throw new InvalidOperationException("Couldnt find menu");
    }
}

public static class CustomListUtils
{
    public static List<Food> ToFoodList(this List<InventoryItem> restaurantMenus)
    {
        List<Food> foodList = new List<Food>();
        for (int i = 0; i < restaurantMenus.Count; i++)
        {
            foodList.Add(restaurantMenus[i].Item);
        }
        return foodList;
    }

    public static bool GetMenu(this List<RestaurantMenu> restaurantMenuList, string menuName, out RestaurantMenu restaurantMenu)
    {
        restaurantMenu = null;
        for (int i = 0; i < restaurantMenuList.Count; i++)
        {
            if (restaurantMenuList[i].Name == menuName)
            {
                restaurantMenu = restaurantMenuList[i];
                return true;
            }
        }
        return false;
    }
}