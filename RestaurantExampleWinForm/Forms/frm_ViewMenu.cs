using Restaurant.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystems;

namespace RestaurantExampleWinForm.Forms
{

    public partial class frm_ViewMenu : Form, IMenuListener
    {
        private IMenuCollection menu;

        public frm_ViewMenu()
        {
            InitializeComponent();
        }

        public void Initialize(IMenuCollection menu)
        {
            OnMenuChanged(menu);
        }

        public void OnMenuChanged(IMenuCollection menu)
        {
            if(this.menu != menu)
            {
                if(this.menu != null) this.menu.RemoveListener(this);

                this.menu = menu;
                this.menu.AddListener(this);
            }

            tv_Menu.Nodes.Clear();
            List<string> menuList = this.menu.GetMenuList();
            for (int i = 0; i < menuList.Count; i++)
            {
                TreeNode menuView = new TreeNode(menuList[i]);
                List<InventoryItem> itemsOf = this.menu.GetItemsOf(menuList[i]);
                for (int j = 0; j < itemsOf.Count; j++)
                {
                    menuView.Nodes.Add($"{itemsOf[j].Item.Name}, {itemsOf[j].Amount}");
                }
                tv_Menu.Nodes.Add(menuView);
            }
        }

        private void frm_ViewMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.RemoveListener(this);
        }
    }
}
