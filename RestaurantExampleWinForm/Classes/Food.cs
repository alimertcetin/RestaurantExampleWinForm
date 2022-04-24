using System;

namespace Restaurant.Data
{
    [System.Serializable]
    public class Food : IEquatable<Food>
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

        public override bool Equals(object other)
        {
            if(!(other is Food))
            {
                return false;
            }
            return other.GetHashCode() == GetHashCode();
        }

        public bool Equals(Food other)
        {
            return other.GetHashCode() == GetHashCode();
        }
    }

}
