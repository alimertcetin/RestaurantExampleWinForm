namespace XIV.InventorySystem
{
    [System.Serializable]
    public class InventoryItem
    {
        public int Amount;
        public object Item;

        //reflection
        private InventoryItem()
        {

        }

        public InventoryItem(int amount, object item)
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