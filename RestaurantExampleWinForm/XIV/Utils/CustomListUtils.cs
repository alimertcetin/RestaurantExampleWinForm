using Restaurant;
using Restaurant.Data;
using System.Collections.Generic;
using XIV.InventorySystems;

namespace XIV.Utils
{
    public static class CustomListUtils
    {
        public static List<Food> ToFoodList(this List<InventoryItem> restaurantMenus)
        {
            List<Food> foodList = new List<Food>();
            for (int i = 0; i < restaurantMenus.Count; i++)
            {
                foodList.Add(restaurantMenus[i].Item);
            }
            return foodList;
        }

        public static bool GetMenu(this List<Menu> restaurantMenuList, string menuName, out Menu restaurantMenu)
        {
            restaurantMenu = null;
            for (int i = 0; i < restaurantMenuList.Count; i++)
            {
                if (restaurantMenuList[i].Name == menuName)
                {
                    restaurantMenu = restaurantMenuList[i];
                    return true;
                }
            }
            return false;
        }
    }
}