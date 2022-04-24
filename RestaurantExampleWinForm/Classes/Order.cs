using Restaurant;
using Restaurant.Data;

public class Order
{
    public int OrderID { get; private set; }
    public string MenuName;
    public MenuSize OrderSize;
    public int MenuCount;
    public double MenuPrice;

    public Order(int orderID, string menuName, MenuSize menuSize, int menuCount, double menuPrice)
    {
        this.OrderID = orderID;
        this.MenuName = menuName;
        this.OrderSize = menuSize;
        this.MenuCount = menuCount;
        this.MenuPrice = menuPrice;
    }

    public override string ToString()
    {
        return $"{OrderID} - {MenuName} x{MenuCount}";
    }
}
