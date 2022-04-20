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
    public partial class frm_MainForm : Form, IMenuCreationListener, IItemAddListener, IItemRemoveListener
    {
        Inventory inventory;
        const string INVENTORY_PATH = "inventory.bin";

        List<RestaurantMenu> menuList;
        const string MENU_PATH = "menu.bin";

        List<Order> orderList = new List<Order>();

        public frm_MainForm()
        {
            InitializeComponent();
        }

        private void frm_MainForm_Load(object sender, EventArgs e)
        {
            inventory = SaveSystem.Load<Inventory>(INVENTORY_PATH);
            menuList = SaveSystem.Load<List<RestaurantMenu>>(MENU_PATH);
            nup_menuAmount.Minimum = 1;
            RefreshFormControls();
        }

        private void RefreshFlpSize()
        {
            if (cmb_Menu.SelectedIndex == -1) return;

            //TODO : menülerden şu anda seçili olanı bul
            RestaurantMenu selectedMenu = menuList[cmb_Menu.SelectedIndex];

            if (selectedMenu.AvailableSizeList == null) return;
            //Menünün boyut seçeneklerini al
            List<MenuSize> sizeOptions = selectedMenu.AvailableSizeList;

            //Radio button olarak flpSize'a ekle
            FlowLayoutUtils.FillWithEnumList<MenuSize, RadioButton>(flp_Size, sizeOptions);
        }

        private void frm_MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSystem.Save(inventory, INVENTORY_PATH);
            SaveSystem.Save(menuList, MENU_PATH);
        }

        private void ts_MalzemeEkle_Click(object sender, EventArgs e)
        {
            frm_EnvantereEkle form = FormUtils.OpenForm<frm_EnvantereEkle>(this.MdiParent);
            form.Initialize(this);
        }

        private void ts_MenuOlustur_Click(object sender, EventArgs e)
        {
            frm_CreateMenu form = FormUtils.OpenForm<frm_CreateMenu>(this.MdiParent);
            form.Initialize(inventory.GetItems().ToFoodList(), this);
        }

        private void ts_MalzemeCikar_Click(object sender, EventArgs e)
        {
            frm_EnvanterdenCikar form = FormUtils.OpenForm<frm_EnvanterdenCikar>(this.MdiParent);
            form.Initialize(this);
        }

        public void OnRestaurantMenuCreated(RestaurantMenu addedMenu)
        {
            for (int i = 0; i < menuList.Count; i++)
            {
                RestaurantMenu menu = menuList[i];
                if(menu.Name == addedMenu.Name)
                {
                    MessageBox.Show($"There is already a menu that has the same name. {addedMenu.Name}");
                    return;
                }
            }
            menuList.Add(addedMenu);
            RefreshFormControls();
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

        //Interface members must be public
        public void OnAddItem(InventoryItem inventoryItem)
        {
            inventory.Add(inventoryItem);
        }

        public void OnRemoveItem(InventoryItem inventoryItem)
        {
            inventory.Remove(inventoryItem.Item, inventoryItem.Amount);
        }

        private void btn_SiparisEkle_Click(object sender, EventArgs e)
        {
            //TODO : Create order, update total price, remove from inventory
            //TODO : Dont allow to create order if inventory doesnt have that item
            string restMenuName = cmb_Menu.Items[cmb_Menu.SelectedIndex].ToString();
            if(!FlowLayoutUtils.GetSelectedRadio(flp_Size, out RadioButton radioButton))
            {
                MessageBox.Show("Select a menu size");
                return;
            }
            MenuSize menuSize = EnumUtils.GetType<MenuSize>(radioButton.Text);
            int orderCount = (int)nup_menuAmount.Value;
            for (int i = 0; i < menuList.Count; i++)
            {
                RestaurantMenu restMenu = menuList[i];
                if(restMenu.Name == restMenuName)
                {
                    if (inventory.Contains(restMenu.GetItems()))
                    {
                        Order order = new Order(orderList.Count, restMenu, menuSize, orderCount);
                        orderList.Add(order);
                        inventory.Remove(restMenu.GetItems());
                    }
                    else
                    {
                        MessageBox.Show("Sorry, this menu is not available right now");
                    }
                }
            }
            RefreshFormControls();
        }

        private void RefreshOrderList()
        {
            lstb_OrderList.Items.Clear();
            for (int i = 0; i < orderList.Count; i++)
            {
                lstb_OrderList.Items.Add(orderList[i].OrderedMenu.Name);
            }
        }

        private void RefreshFormControls()
        {
            RefreshOrderList();
            RefreshMenuCmb();
            RefreshFlpSize();
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
    }
}

public class Order
{
    public int OrderID { get; private set; }
    public RestaurantMenu OrderedMenu;
    public MenuSize OrderSize;
    public int MenuCount;

    public Order(int orderID)
    {
        this.OrderID = orderID;
    }

    public Order(int orderID, RestaurantMenu orderedMenu, MenuSize menuSize, int menuCount)
    {
        this.OrderID = orderID;
        this.OrderedMenu = orderedMenu;
        this.OrderSize = menuSize;
        this.MenuCount = menuCount;
    }

    public override string ToString()
    {
        return $"{OrderID} - {OrderedMenu.Name} x{MenuCount}";
    }
}

public static class ListUtils
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
}