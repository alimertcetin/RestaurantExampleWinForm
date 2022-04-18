using System.Collections.Generic;
using XIV.InventorySystem;

namespace Restaurant
{
    [System.Serializable]
    public class RestaurantMenu
    {
        List<InventoryItem> items = new List<InventoryItem>();

        public string Name;
        public double Price;

        /// <summary>
        /// Returns a copy of items
        /// </summary>
        /// <returns>A copy of items</returns>
        public List<InventoryItem> GetItems()
        {
            return new List<InventoryItem>(items);
        }

        public static RestaurantMenu CreateMenu(string menuName, double price, params InventoryItem[] items)
        {
            var menu = new RestaurantMenu();
            menu.Name = menuName;
            menu.Price = price;
            for (int i = 0; i < items.Length; i++)
            {
                menu.items.Add(items[i]);
            }
            return menu;
        }
    }
}
