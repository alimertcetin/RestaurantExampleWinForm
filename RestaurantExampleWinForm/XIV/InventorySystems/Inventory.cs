using Restaurant.Data;
using Restaurant.Interfaces;
using System.Collections.Generic;
using XIV.SaveSystems;

namespace XIV.InventorySystems
{
    public class Inventory : IInventory, ISaveable
    {
        private List<InventoryItem> inventoryItems;
        private List<IInventoryListener> inventoryListeners;
        private double money;

        public Inventory()
        {
            inventoryItems = new List<InventoryItem>();
            inventoryListeners = new List<IInventoryListener>();
            money = 0;
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

        public bool Add(InventoryItem itemToAdd)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem item = inventoryItems[i];
                if (item.Item.Name == itemToAdd.Item.Name)
                {
                    item.Amount += itemToAdd.Amount;
                    inventoryItems[i] = item;
                    InvokeListeners();
                    return true;
                }
            }

            inventoryItems.Add(itemToAdd);
            InvokeListeners();
            return true;
        }

        private bool Remove(Food itemToRemove, int amount)
        {
            for (int i = 0; i < inventoryItems.Count; i++)
            {
                InventoryItem item = inventoryItems[i];
                if (item.Item.Name == itemToRemove.Name)
                {
                    if(item.Amount - amount < 0)
                    {
                        return false;
                    }
                    item.Amount -= amount;
                    inventoryItems[i] = item;
                    if (item.Amount == 0)
                    {
                        inventoryItems.RemoveAt(i);
                    }
                    return true;
                }
            }
            return false; //Item doesnt exist
        }

        public bool Remove(InventoryItem inventoryItem)
        {
            bool flag = Remove(inventoryItem.Item, inventoryItem.Amount);
            if(flag) InvokeListeners();

            return flag;
        }

        public void AddMoney(double v)
        {
            money += v;
            InvokeListeners();
        }

        public void AddListener(IInventoryListener inventoryListener)
        {
            if (!inventoryListeners.Contains(inventoryListener))
            {
                inventoryListeners.Add(inventoryListener);
            }
        }

        public void RemoveListener(IInventoryListener inventoryListener)
        {
            if (inventoryListeners.Contains(inventoryListener))
            {
                inventoryListeners.Remove(inventoryListener);
            }
        }

        private void InvokeListeners()
        {
            for (int i = 0; i < inventoryListeners.Count; i++)
            {
                inventoryListeners[i].OnInventoryChanged(this);
            }
        }

        public object GetSaveData()
        {
            return new SaveData
            {
                InventoryItems = this.inventoryItems,
                Money = this.money,
            };
        }

        public void Load(object loadedData)
        {
            SaveData saveData = (SaveData)loadedData;
            this.inventoryItems = saveData.InventoryItems;
            this.money = saveData.Money;
        }

        [System.Serializable]
        private struct SaveData
        {
            public List<InventoryItem> InventoryItems;
            public double Money;
        }
    }
}