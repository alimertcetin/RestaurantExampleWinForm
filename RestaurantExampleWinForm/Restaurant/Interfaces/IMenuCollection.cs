using System.Collections.Generic;
using XIV.InventorySystems;

namespace Restaurant.Interfaces
{
    public interface IMenuCollection
    {
        List<string> GetMenuList();
        List<InventoryItem> GetItemsOf(string menuName);
        bool Add(string menuName, Menu restaurantMenu);
        bool Remove(string menuName);
        void AddListener(IMenuListener menuListener);
        void RemoveListener(IMenuListener menuListener);
    }
}
