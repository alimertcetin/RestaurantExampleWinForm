using Restaurant.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XIV.InventorySystems;
using XIV.SaveSystems;

namespace Restaurant.Data
{
    public class MenuCollection : IMenuCollection, ISaveable
    {
        // There is another class called Menu for winform
        // TODO : Find a better name for Menu
        private Dictionary<string, Menu> menu;
        private List<IMenuListener> menuListeners;

        public MenuCollection()
        {
            menu = new Dictionary<string, Menu>();
            menuListeners = new List<IMenuListener>();
        }

        public bool Add(string menuName, Menu item)
        {
            try
            {
                menu.Add(menuName, item);
                InvokeListeners();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool Remove(string menuName)
        {
            try
            {
                menu.Remove(menuName);
                InvokeListeners();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool Contains(string menuName)
        {
            return menu.ContainsKey(menuName);
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

        public List<InventoryItem> GetItemsOf(string menuName)
        {
            if (menu.TryGetValue(menuName, out var restaurantMenu))
            {
                return restaurantMenu.GetItems();
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

        public double GetPriceOf(string menuName)
        {
            if (menu.TryGetValue(menuName, out var restaurantMenu))
            {
                return restaurantMenu.Price;
            }
            throw new InvalidOperationException("Couldnt find menu");
        }

        private void InvokeListeners()
        {
            for (int i = 0; i < menuListeners.Count; i++)
            {
                menuListeners[i].OnMenuChanged(this);
            }
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

        public object GetSaveData()
        {
            return this.menu;
        }

        public void Load(object loadedData)
        {
            this.menu = (Dictionary<string, Menu>)loadedData;
        }
    }
}