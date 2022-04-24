using Restaurant;
using Restaurant.Data;
using System;
using System.Collections.Generic;

namespace XIV.InventorySystem
{
    [System.Serializable]
    public class Inventory
    {
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private double money;

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

        public bool IsLegitOrder(int orderCount, List<InventoryItem> selectedMenuItems)
        {
            for (int i = 0; i < selectedMenuItems.Count; i++)
            {
                InventoryItem inventoryItem = selectedMenuItems[i];
                if (!Contains(inventoryItem.Item, inventoryItem.Amount * orderCount))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Contains(Food food)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].Item.Equals(food))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(Food food, int amount)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem inventoryItem = inventoryItems[i];
                if (inventoryItem.Item.Equals(food) && inventoryItem.Amount - amount >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(InventoryItem itemToAdd)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem item = inventoryItems[i];
                if (item.Equals(itemToAdd.Item))
                {
                    item.Amount += itemToAdd.Amount;
                    inventoryItems[i] = item;
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
                    if(item.Amount - amount < 0)
                    {
                        System.Windows.Forms.MessageBox.Show("You cant remove non exist item");
                        break;
                    }
                    item.Amount -= amount;
                    inventoryItems[i] = item;
                    if (item.Amount <= 0)
                    {
                        inventoryItems.RemoveAt(i);
                    }
                    break;
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

        public void AddMoney(double v)
        {
            money += v;
        }
    }
}