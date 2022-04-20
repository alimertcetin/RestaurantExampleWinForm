using Restaurant.Data;
using System.Collections.Generic;
namespace XIV.InventorySystem
{
    [System.Serializable]
    public class Inventory
    {
        List<InventoryItem> inventoryItems = new List<InventoryItem>();

        public Inventory()
        {

        }

        /// <summary>
        /// Returns a copy of item list
        /// </summary>
        /// <returns>A copy of item list</returns>
        public List<InventoryItem> GetItems()
        {
            return new List<InventoryItem>(inventoryItems);
        }

        public bool Contains(Food food)
        {
            foreach (InventoryItem inventoryItem in inventoryItems)
            {
                if (inventoryItem.Item.Equals(food))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(List<InventoryItem> inventoryItems)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (!Contains(inventoryItems[i].Item))
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(InventoryItem itemToAdd)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem item = inventoryItems[i];
                if (item.Equals(itemToAdd.Item))
                {
                    item.Amount += itemToAdd.Amount;
                    return;
                }
            }

            inventoryItems.Add(itemToAdd);
        }

        public void RemoveAll(object itemToRemove)
        {
            for (int i = inventoryItems.Count - 1; i >= 0; i--)
            {
                if (inventoryItems[i].Equals(itemToRemove))
                {
                    inventoryItems.RemoveAt(i);
                }
            }
        }

        public void Remove(object itemToRemove, int amount)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem item = inventoryItems[i];
                if (item.Equals(itemToRemove))
                {
                    item.Amount -= amount;
                    if (item.Amount <= 0)
                    {
                        inventoryItems.RemoveAt(i);
                    }
                }
            }
        }

        public void Remove(InventoryItem inventoryItem)
        {
            Remove(inventoryItem.Item, inventoryItem.Amount);
        }

        public void Remove(List<InventoryItem> inventoryItems)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem inventoryItem = inventoryItems[i];
                Remove(inventoryItem.Item, inventoryItem.Amount);
            }
        }
    }
}