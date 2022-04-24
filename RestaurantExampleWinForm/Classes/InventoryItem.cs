using Restaurant.Data;
using System;

namespace XIV.InventorySystem
{
    [System.Serializable]
    public struct InventoryItem : IEquatable<InventoryItem>
    {
        public int Amount;
        public Food Item;

        public InventoryItem(int amount, Food item)
        {
            this.Amount = amount;
            this.Item = item;
        }

        public override int GetHashCode()
        {
            return Item.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return Item.GetHashCode() == other.GetHashCode();
        }

        public bool Equals(InventoryItem other)
        {
            return Item.GetHashCode() == other.GetHashCode();
        }
    }
}