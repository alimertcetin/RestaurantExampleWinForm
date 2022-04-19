using System;

namespace Restaurant.Data
{
    [System.Serializable]
    public class Food
    {
        public string ID { get; private set; }
        public string Name;
        public double Price;
        public FoodType FoodType;

        public Food(string name, double price, FoodType type)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Name = name;
            this.Price = price;
            this.FoodType = type;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

}
