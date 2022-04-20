using Restaurant.Data;

namespace XIV.InventorySystem
{
    [System.Serializable]
    public class InventoryItem
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

        public override bool Equals(object obj)
        {
            return Item.GetHashCode() == obj.GetHashCode();
        }
    }
}