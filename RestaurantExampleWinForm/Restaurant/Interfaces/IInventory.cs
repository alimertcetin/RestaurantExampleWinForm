using System.Collections.Generic;
using XIV.InventorySystems;

namespace Restaurant.Interfaces
{
    public interface IInventory
    {
        List<InventoryItem> GetItems();
        bool Add(InventoryItem inventoryItem);
        bool Remove(InventoryItem inventoryItem);
        void AddListener(IInventoryListener inventoryListener);
        void RemoveListener(IInventoryListener inventoryListener);
    }
}
