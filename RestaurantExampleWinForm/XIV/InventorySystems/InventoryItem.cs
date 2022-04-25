using Restaurant.Data;

namespace XIV.InventorySystems
{
    [System.Serializable]
    public struct InventoryItem
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
    }
}