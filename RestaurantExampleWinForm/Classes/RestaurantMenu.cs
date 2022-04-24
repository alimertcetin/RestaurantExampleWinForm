using Restaurant.Data;
using System;
using System.Collections.Generic;
using XIV.InventorySystem;

namespace Restaurant
{
    [System.Serializable]
    public class RestaurantMenu : IEquatable<RestaurantMenu>
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

        public static RestaurantMenu CreateMenu(string menuName, 
            double price,
            List<MenuSize> availableSizeList,
            params InventoryItem[] items)
        {
            var menu = new RestaurantMenu();
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
            if (!(other is RestaurantMenu)) return false;

            return other.GetHashCode() == GetHashCode();
        }

        public bool Equals(RestaurantMenu other)
        {
            return other.GetHashCode() == GetHashCode();
        }
    }
}
