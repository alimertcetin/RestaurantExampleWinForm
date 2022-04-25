namespace Restaurant.Interfaces
{
    public interface IInventoryListener
    {
        void OnInventoryChanged(IInventory inventory);
    }
}
