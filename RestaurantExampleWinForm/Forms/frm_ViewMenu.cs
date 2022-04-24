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

namespace RestaurantExampleWinForm.Forms
{
    public interface IMenuHolder
    {
        List<string> GetMenuList();
        List<InventoryItem> GetItemsOf(string menuName);
        void AddListener(IMenuListener menuListener);
        void RemoveListener(IMenuListener menuListener);
    }
    public interface IMenuListener
    {
        void RefreshMenu();
    }

    public partial class frm_ViewMenu : Form, IMenuListener
    {
        private IMenuHolder menuHolder;


        public frm_ViewMenu()
        {
            InitializeComponent();
        }

        public void Initialize(IMenuHolder menuHolder)
        {
            this.menuHolder = menuHolder;
            this.menuHolder.AddListener(this);
            RefreshMenu();
        }

        public void RefreshMenu()
        {
            tv_Menu.Nodes.Clear();
            List<string> menuList = menuHolder.GetMenuList();
            for (int i = 0; i < menuList.Count; i++)
            {
                TreeNode menuView = new TreeNode(menuList[i]);
                List<InventoryItem> itemsOf = menuHolder.GetItemsOf(menuList[i]);
                for (int j = 0; j < itemsOf.Count; j++)
                {
                    menuView.Nodes.Add($"{itemsOf[j].Item.Name}, {itemsOf[j].Amount}");
                }
                tv_Menu.Nodes.Add(menuView);
            }
        }

        private void frm_ViewMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuHolder.RemoveListener(this);
        }
    }
}
