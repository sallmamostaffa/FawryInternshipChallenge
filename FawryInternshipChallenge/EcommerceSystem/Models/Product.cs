namespace EcommerceSystem.Models
{
    public abstract class Product
    {
        protected string Name { get; set; }
        protected double Price { get; set; }
        protected int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string GetName() => Name;
        public double GetPrice() => Price;
        public int GetQuantity() => Quantity;
        public void ReduceQuantity(int amount) => Quantity -= amount;

        public abstract bool IsExpired();
    }
}