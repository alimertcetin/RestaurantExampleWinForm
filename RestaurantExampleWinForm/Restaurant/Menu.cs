using Restaurant.Data;
using System;
using System.Collections.Generic;
using XIV.InventorySystems;

namespace Restaurant
{
    [System.Serializable]
    public class Menu : IEquatable<Menu>
    {
        List<InventoryItem> items = new List<InventoryItem>();

        public string Name;
        public double Price;
        public List<MenuSize> AvailableSizeList = new List<MenuSize>();

        /// <summary>
        /// Returns a copy of items
        /// </summary>
        /// <returns>A copy of items</returns>
        public List<InventoryItem> GetItems()
        {
            return new List<InventoryItem>(items);
        }

        public static Menu CreateMenu(string menuName, 
            double price,
            List<MenuSize> availableSizeList,
            params InventoryItem[] items)
        {
            var menu = new Menu();
            menu.Name = menuName;
            menu.Price = price;
            menu.AvailableSizeList = availableSizeList;
            for (int i = 0; i < items.Length; i++)
            {
                menu.items.Add(items[i]);
            }
            return menu;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is Menu)) return false;

            return other.GetHashCode() == GetHashCode();
        }

        public bool Equals(Menu other)
        {
            return other.GetHashCode() == GetHashCode();
        }
    }
}
